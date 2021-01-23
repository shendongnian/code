    var obj  = JsonConvert.DeserializeObject<MyObj>(json);
---
    public class MyObj
    {
        public string Id { get; set; }
        [JsonProperty("Parent.Id")]
        public string ParentId { get; set; }
        [JsonProperty("Agent.Id")]
        public string AgentId { get; set; }
        [JsonProperty("Agent.Profile.FullName")]
        public string ProfileFullName { get; set; }
        public string Fee { get; set; }
        public string FeeManagementDate { get; set; }
        [JsonProperty("Contact.Name")]
        public string ContactName { get; set; }
        [JsonProperty("Contact.Telephone")]
        public string ContactTelephone { get; set; }
        [JsonProperty("Contact.Email")]
        public string ContactEmail { get; set; }
        public string AgreementUrl { get; set; }
    }
