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
                    IEnumerable<Meta<IService>> services = 
                        context.Resolve<IEnumerable<Meta<IService>>>(); 
                    return services.ToDictionary(m => (String)m.Metadata["Key"], 
                                                 m => m.Value);
                };
            }
            return valueProvider != null;
        }
    }
