    public class Design : MarkupExtension
    {
        readonly object realValue;
        readonly object designValue;
        public Design(object realValue, object designValue)
        {
            this.realValue = realValue;
            this.designValue = designValue;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var target = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            if (target != null && target.TargetObject != null)
            {
                var obj = target.TargetObject as DependencyObject;
                if (obj != null && DesignerProperties.GetIsInDesignMode(obj))
                    return designValue;
            }
            return realValue;
        }
    }
