    using System;
    using Newtonsoft.Json;
    using net.openstack.Core.Domain;
    namespace net.openstack.Core.Request
    {
        [JsonObject(MemberSerialization.OptIn)]
        internal class AddTenantRequest
        {
            [JsonProperty("tenant")]
            public NewTenant Tenant { get; private set; }
            public AddTenantRequest(NewTenant tenant)
            {
                if (tenant == null)
                    throw new ArgumentNullException("tenant");
                Tenant = tenant;
            }
        }
    }
