    [DataContract]
    public class BaseDTO
    {
        // Rest of the properties
    
        [DataMember]
        public dynamic data { get; set; }
    
        public LoginDTO LoginInfo
        {
            get
            {
                var jObjectData = data as JObject;
                if (jObjectData == null)
                {
                    return null;
                }
    
                try
                {
                    return jObjectData.ToObject<LoginDTO>();
                }
                catch
                {
                    return null;
                }
            }
        }
    }
