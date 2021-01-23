    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    
    namespace WcfKnownTypeStackOverFlow
    {
        public class Service1 : IService1
        {
         public ResponseDTO GetDataFromWebService(RequestDTO request)
         {
               ResponseDTO response = null;
               switch(request)
               {
                   case RequestDTO.Request1:
                       {
                           AddressDTO addrDto = new AddressDTO();
                           Address addr = new Address();
                           addrDto.Elements = new List<Address>() 
                           { 
                               new Address                          
                               { 
                                   City ="mycity", 
                                   Street="mystreet"}, 
                               new Address
                               {
                                   City="yourcity", 
                                   Street="yourcity"}};
    
                           response =  (ResponseDTO)addrDto;
                           break;
                       }
                  case RequestDTO.Request2:
                   default:
                      {
                         response = new ResponseDTO();
                         response.ID = "responseDto";
                         break;
                     }
               }
               return response;
            }
        }
    }
