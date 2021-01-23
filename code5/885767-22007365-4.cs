    using System.ServiceModel;
    namespace WcfService1
    {
        [ServiceBehavior]
        public class Service1 : IService1, IService2
        {
            public DTOCountry[] GetAllCountries()
            {
                return new DTOCountry[2] { new DTOCountry { Name = "a" }, new DTOCountry { Name = "b" } };
            }
    
            public DTOCountry[] GetAllCountries2()
            {
                return new DTOCountry[2] { new DTOCountry { Name = "a" }, new DTOCountry { Name = "b" } };
            }
        }
    }
