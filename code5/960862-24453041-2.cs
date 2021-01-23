    using net.openstack.Core.Domain;
    using Newtonsoft.Json;
    namespace net.openstack.Core.Response
    {
        [JsonObject(MemberSerialization.OptIn)]
        internal class NewTenantResponse
        {
            [JsonProperty("tenant")]
            public NewTenant NewTenant { get; private set; }
        }
        [JsonObject(MemberSerialization.OptIn)]
        internal class TenantResponse
        {
            [JsonProperty("tenant")]
            public Tenant Tenant { get; private set; }
        }
    }
