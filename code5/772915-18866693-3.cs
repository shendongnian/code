    interface IPropertyListOwner<T>
      where T : IProperty
    {
        ObservableCollection<T> Properties { get; }
    }
    abstract class AbstractItem<T> : IPropertyListOwner<T>
      where T : IProperty
    {
        public abstract ObservableCollection<T> Properties { get; }
    }
    class ConcreteProperty : IProperty { }
    class ConcreteItem : AbstractItem<ConcreteProperty>
    {
        public override ObservableCollection<ConcreteProperty> Properties 
        { 
            get
            {
                // ...
            }
        }
    }
