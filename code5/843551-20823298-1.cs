    [ContentProperty("Name")]
    public class Reference : System.Windows.Markup.Reference
    {
        public Reference()
            : base()
        { }
        public Reference(string name)
            : base(name)
        { }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            IProvideValueTarget valueTargetProvider = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            if (valueTargetProvider != null)
            {
                DependencyObject targetObject = valueTargetProvider.TargetObject as DependencyObject;
                if (targetObject != null && DesignerProperties.GetIsInDesignMode(targetObject))
                {
                     return null;
                }
            }
            return base.ProvideValue(serviceProvider);
        }
