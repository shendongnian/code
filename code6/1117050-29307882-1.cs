    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    using AutoMapper;
    
    namespace YourAppNamespace
    {
        public class AutoMapperConfig
        {
            public static void Configure()
            {
                Mapper.CreateMap<MyDataObject, service1.IdenticalObject>();
                Mapper.CreateMap<MyDataObject, service2.IdenticalObject>();
            }
        }
    }
