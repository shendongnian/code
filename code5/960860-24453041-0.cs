    using Newtonsoft.Json;
    namespace net.openstack.Core.Domain
    {
        [JsonObject(MemberSerialization.OptIn)]
        public class NewTenant
        {
            /// <summary>
            /// Gets the ID for the new user.
            /// <note type="warning">The value of this property is not defined. Do not use.</note>
            /// </summary>
            [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include)]
            public string Id { get; private set; }
            [JsonProperty("name")]
            public string Name { get; private set; }
            [JsonProperty("description")]
            public string Description { get; private set; }
            [JsonProperty("enabled")]
            public bool Enabled { get; private set; }
            public NewTenant(string name, string description, bool enabled = true)
            {
                Name = name;
                Description = description;
                Enabled = enabled;
            }
        }
    }
