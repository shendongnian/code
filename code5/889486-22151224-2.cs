        [AttributeUsage(AttributeTargets.Property)]
        public class MyRemoteAttribute : RemoteAttribute
        {
            public MyRemoteAttribute(Type type, string propertyName)
                : base(MyRemoteAttributeDataProvider.GetAttributeData(type,propertyName).Action,               MyRemoteAttributeDataProvider.GetAttributeData(type,propertyName).Controller)
            {
                var data = MyRemoteAttributeDataProvider.GetAttributeData(type,propertyName);
                base.ErrorMessage = data.ErrorMessage;
                base.HttpMethod = data.HttpMethod;
            }
        }
    
        public static class MyRemoteAttributeDataProvider
        {
            public static RemoteAttributeData GetAttributeData(Type type
               , string propertyName)
            {
                //this is where you are going to implement your logic im just implementing                 as an example
                //you can pass in a different type to get your values. For example you can  pass in a service to get required values.
    
                //property specific logic here, again im going to implement to make this
                //specification by example
               var attrData = new RemoteAttributeData();            
               if(propertyName == "MyOtherProperty")
               {
                    attrData.Action = "MyOtherPropertyRelatedAction";
                    attrData.Controller = "MyOtherPropertyRelatedController";
                    attrData.ErrorMessage = "MyOtherPropertyRelated Error Message";
                    attrData.HttpMethod = "POST";
               }            
               else 
               {            
                    attrData.Action = "UserNameExists";
                    attrData.Controller = "AccountController";
                    attrData.ErrorMessage = "Some Error Message";
                    attrData.HttpMethod = "POST";
               }
               return attrData;
            }
        }
    
        public class RemoteAttributeData
        {
            public string Controller { get; set; }
            public string Action { get; set; }
            public string HttpMethod { get; set; }
            public string ErrorMessage { get; set; }
        }
