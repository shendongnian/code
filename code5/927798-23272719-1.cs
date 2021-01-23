    using System;
    
    namespace DomainManager
    {
        public class ShadowDomainManager : AppDomainManager
        {
            public override void InitializeNewDomain(AppDomainSetup appDomainInfo)
            {
                appDomainInfo.ShadowCopyFiles = "true";
                base.InitializeNewDomain(appDomainInfo);
            }
        }
    }
