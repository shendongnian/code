    public class AlternateAppDomainStrategy<T> : ActivationStrategy
        {
            public override void Activate(IContext context, InstanceReference reference) 
            {
                if (reference.Instance.GetType().GetInterfaces().Contains(typeof(T)))
                {
                    var type = reference.Instance.GetType();
    
                    var configFilePath = type.Assembly.GetName().Name + ".dll.config";
                    var file = new FileInfo(configFilePath);
                    if (file.Exists)
                    {
                        var setup = new AppDomainSetup() { ConfigurationFile = file.FullName, ApplicationBase = AppDomain.CurrentDomain.BaseDirectory };
                        var domain = AppDomain.CreateDomain(type.FullName, null, setup);
    
                        domain.Load(type.Assembly.FullName);
    
                        var instance = domain.CreateInstanceAndUnwrap(type.Assembly.FullName, type.FullName);
    
                        reference.Instance = instance;
                    }
                    else
                    {
                        throw new FileNotFoundException("Missing config file", file.FullName);
                    }
                }
            }
        }
