    namespace Ns1.Ns2.Domain
    {
        public class Process
        {
            private IIndex IndexBuilderConcr { get; set; }
    
            public Processo(String processType) {
                IndexBuilderConcr = new UnityContainer().Resolve<IIndex>(processType);
            }
        }
    }
