    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
        public class RDPPublication : DataService<CDP.RDP.DataAccess.Publication.RDPEntities>
        {
            //private IRDPPublicationServiceV2 _rdpPublicationService;
    
            public RDPPublication()
            {
                //_rdpPublicationService = UIUnityRegistry.GetInstance().Resolve<IRDPPublicationServiceV2>();
            }
    
            public static void InitializeService(DataServiceConfiguration config)
            {
                config.UseVerboseErrors = true;
                config.MaxExpandCount = 300;
                config.MaxExpandDepth = 300;
                config.SetEntitySetAccessRule("*", EntitySetRights.AllRead  | EntitySetRights.WriteMerge | EntitySetRights.WriteReplace);
                config.SetServiceOperationAccessRule("*", ServiceOperationRights.AllRead);
                config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
            }
    
            protected override void OnStartProcessingRequest(ProcessRequestArgs args)
            {
                base.OnStartProcessingRequest(args);
    
                CurrentDataSource.Ponderation.Include("TypePonderation").ToList();
            }
        }
