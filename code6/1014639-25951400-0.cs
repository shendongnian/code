      public class ServiceChangeWrapper
      {
        public ServiceChange itil_change { get; set; }
      }
...
    public static string CreateServiceChange(ServiceChange change)
        {
            ServiceChangeWrapper wrapper = new ServiceChangeWrapper { itil_change = change};
            string json = JsonConvert.SerializeObject(wrapper);
            return json;
        }
