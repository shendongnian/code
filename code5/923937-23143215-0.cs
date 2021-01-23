    // add attribute so this only targets properties, or whatever you want
    public class JiraAttribute : Attribute
    {
        public string LookupId { get; private set; }
        public JiraAttribute(string lookupId)
        {
            this.LookupId = lookupId;
        }
    }
    public class JiraContractResolver : DefaultContractResolver
    {
        public static readonly JiraContractResolver Instance = new JiraContractResolver();
    
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
    
            var attr = member.GetCustomAttributes(typeof(JiraAttribute), true).Cast<JiraAttribute>().ToList();
            if (attr != null && attr.Count > 0)
            {
                property.PropertyName = ConfigurationManager.AppSettings[attr[0].LookupId];
            }
    
            return property;
        }
    }
    // in a class
    [Jira("JiraResolutionTypeId")]
    public string ResolutionType { get; set; }
    //e.g.
    // ConfigurationManager.AppSettings["JiraResolutionTypeId"] == "customfield_10200"
    var settings = new JsonSerializerSettings { ContractResolver = JiraContractResolver.Instance };
    var s = JsonConvert.SerializeObject(new Priority { Id = "123", ResolutionType = "abc" }, settings);
    // {"id":"123","name":null,"iconUrl":null,"customfield_10200":"abc"}
    var d = JsonConvert.DeserializeObject<Priority>(s, settings);
    // d.ResolutionType == "abc"
