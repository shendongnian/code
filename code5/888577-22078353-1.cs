    internal sealed class FieldPropertyDescriptor<TComponent, TField> : PropertyDescriptor
    {
        private readonly FieldInfo fieldInfo;
        public FieldPropertyDescriptor(string name)
            : base(name, null)
        {
            fieldInfo = typeof(TComponent).GetField(Name);
        }
        public override bool IsReadOnly { get { return false; } }
        public override void ResetValue(object component) { }
        public override bool CanResetValue(object component) { return false; }
        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }
        public override Type ComponentType
        {
            get { return typeof(TComponent); }
        }
        public override Type PropertyType
        {
            get { return typeof(TField); }
        }
        public override object GetValue(object component)
        {
            return fieldInfo.GetValue(component);
        }
        public override void SetValue(object component, object value)
        {
            fieldInfo.SetValue(component, value);
            OnValueChanged(component, EventArgs.Empty);
        }
    }
