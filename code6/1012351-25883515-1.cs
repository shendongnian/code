    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using System.ServiceModel.Activation;
    
    namespace WCFSeviceWebHttpBinding
    {
        // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
        [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
        public class Service1 : IService1
        {
    
            public string DoWork()
            {
                return "Hello";
            }
        }
    }
