    public class ServiceParameter : Parameter
    {
        public override Boolean CanSupplyValue(ParameterInfo pi,
            IComponentContext context, out Func<Object> valueProvider)
        {
            valueProvider = null;
            if (pi.Name == "services" 
                && pi.ParameterType == typeof(Dictionary<String, IService>))
            {
                valueProvider = () =>
                {
                    return new Dictionary<string, IService> {
                        { "a", context.ResolveNamed<IService>("a") }, 
                        { "b", context.ResolveNamed<IService>("b") } 
                    };
                };
            }
            return valueProvider != null;
        }
    }
