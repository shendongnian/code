    [AttributeUsage(AttributeTargets.Property)]
    public class MyRemoteAttribute : RemoteAttribute
    {
        public MyRemoteAttribute(Type type)
            : base(MyRemoteAttributeDataProvider.GetAttributeData(type).Action,               MyRemoteAttributeDataProvider.GetAttributeData(type).Controller)
        {
            var data = MyRemoteAttributeDataProvider.GetAttributeData(type);
            base.ErrorMessage = data.ErrorMessage;
            base.HttpMethod = data.HttpMethod;
        }
    }
    public static class MyRemoteAttributeDataProvider
    {
        public static RemoteAttributeData GetAttributeData(Type type)
        {
            //this is where you are going to implement your logic im just implementing as an example
            //you can pass in a different type to get your values. For example you can pass in a service to get required values.
            var attrData = new RemoteAttributeData();
            attrData.Action = "UserNameExists";
            attrData.Controller = "AccountController";
            attrData.ErrorMessage = "Some Error Message";
            attrData.HttpMethod = "POST";
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
