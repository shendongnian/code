    abstract class OptionValue<TTarget>
    {
        private PropertyInfo _propertyInfo;
        public TTarget TargetObject { get; private set; }
        public OptionSource Source { get; private set; }
        public string OptionName { get { return _propertyInfo.Name; } }
        protected OptionValue(TTarget targetObject, OptionSource source, string optionName)
        {
            TargetObject = targetObject;
            Source = source;
            _propertyInfo = typeof(TTarget).GetProperty(optionName);
        }
        public object GetValue()
        {
            return _propertyInfo.GetValue(TargetObject);
        }
        public void SetValue(object value)
        {
            _propertyInfo.SetValue(TargetObject, value);
        }
        public abstract void SetValueFromText(string text);
        public static OptionValue<TTarget, TProperty> Create<TTarget, TProperty>(
            TTarget targetObject, TProperty defaultValue, OptionSource source, string optionName)
        {
            return new OptionValue<TTarget, TProperty>(targetObject, defaultValue, source, optionName);
        }
    }
    class OptionValue<TTarget, TProperty> : OptionValue<TTarget>
    {
        public TProperty DefaultValue { get; private set; }
        public OptionValue(TTarget targetObject, TProperty defaultValue,
            OptionSource source, string optionName)
            : base(targetObject, source, optionName)
        {
            DefaultValue = defaultValue;
        }
        public TProperty GetValue()
        {
            return (TProperty)base.GetValue();
        }
        public void SetValue(TProperty value)
        {
            base.SetValue(value);
        }
        public override void SetValueFromText(string text)
        {
            SetValue((TProperty)Convert.ChangeType(text, typeof(TProperty)));
        }
    }
