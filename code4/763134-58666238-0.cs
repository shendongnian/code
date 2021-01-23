public class SomeClass : DynamicObject, INotifyPropertyChanged {
    private string _StaticStringProperty;
    public string StaticStringProperty { get => _StaticStringProperty; set => SetField(ref _StaticStringProperty, value); }
    private Dictionary<string, object> _DynamicProperties = new Dictionary<string, object>();
    public override IEnumerable<string> GetDynamicMemberNames()
    {
        yield return "DynamicStringProperty";
        yield return "DynamicIntProperty";
    }
    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
        result = _DynamicProperties.GetValueOrDefault(binder.Name, null);
        return true;
    }
    public override bool TrySetMember(SetMemberBinder binder, object value)
    {
        _DynamicProperties[binder.Name] = value;
        RaisePropertyChanged(binder.Name);
        return true;
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void RaisePropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    protected bool SetField<T>(ref T target, T value, [CallerMemberName]string caller = null)
    {
        if (EqualityComparer<T>.Default.Equals(target, value))
            return false;
        target = value;
        RaisePropertyChanged(caller);
        return true;
    }
}
now let it implement `ICustomPropertyProvider`:
public class SomeClass : DynamicObject, ICustomPropertyProvider, INotifyPropertyChanged {
    ...
    public Type Type => GetType();
    public string GetStringRepresentation() => ToString();
    public ICustomProperty GetCustomProperty(string name)
    {
        switch (name)
        {
            // the caveat is that you have to provide all the static properties, too...
            case nameof(StaticStringProperty):
                return new DynamicCustomProperty<SomeClass, string>()
                {
                    Name = name,
                    Getter = (target) => target.StaticStringProperty,
                    Setter = (target, value) => target.StaticStringProperty = value,
                };
            case "DynamicStringProperty":
                return new DynamicCustomProperty<SomeClass, string>()
                {
                    Name = name,
                    Getter = (target) => target.DynamicStringProperty,
                    Setter = (target, value) => target.DynamicStringProperty = value,
                };
            case "DynamicIntegerProperty":
                return new DynamicCustomProperty<SomeClass, int>()
                {
                    Name = name,
                    Getter = (target) => target.DynamicIntegerProperty,
                    Setter = (target, value) => target.DynamicIntegerProperty = value,
                };
            }
        }
        throw new NotImplementedException();
    }
    ...
}
and be able to provide the `DynamicCustomProperty`:
public class DynamicCustomProperty<TOwner, TValue> : ICustomProperty
{
    public Func<dynamic, TValue> Getter { get; set; }
    public Action<dynamic, TValue> Setter { get; set; }
    public Func<dynamic, object, TValue> IndexGetter { get; set; }
    public Action<dynamic, object, TValue> IndexSetter { get; set; }
    public object GetValue(object target) => Getter.Invoke(target);
    public void SetValue(object target, object value) => Setter.Invoke(target, (TValue)value);
    public object GetIndexedValue(object target, object index) => IndexGetter.Invoke(target, index);
    public void SetIndexedValue(object target, object value, object index) => IndexSetter.Invoke(target, index, (TValue)value);
    public bool CanRead => Getter != null || IndexGetter != null;
    public bool CanWrite => Setter != null || IndexSetter != null;
    public string Name { get; set; }
    public Type Type => typeof(TValue);
}
finally we're able to bind them in XAML:
<TextBox Header="Static String" Text="{Binding StaticStringProperty, Mode=TwoWay}"/>
<TextBox Header="Dynamic String" Text="{Binding DynamicStringProperty, Mode=TwoWay}"/>
<TextBox Header="Dynamic Integer" Text="{Binding DynamicIntegerProperty, Mode=TwoWay}"/>
