    public class InfrastructureRegistry : Registry
    {
        public InfrastructureRegistry ()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
               
            });
            //any spefic implementation   
        }
    }              
