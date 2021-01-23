    using System;
    
    namespace DomainManager
    {
        public class ShadowDomainManager : AppDomainManager
        {
            public override void InitializeNewDomain(AppDomainSetup appDomainInfo)
            {
                base.InitializeNewDomain(appDomainInfo); //Currently does not do anything.
                appDomainInfo.ShadowCopyFiles = "true";
            }
        }
    }
