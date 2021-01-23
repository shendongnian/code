    [DataContract]
    public class Resource 
    {
        [IgnoreDataMember]
        public ResourceId ResourceId { get; set; }
        [DataMember(Name="user_id")]
        private int? user_id {
            get
            {
                return ResourceId == null ? (int ?)null : ResourceId.UserId;
            }
            set
            {
                if (value == null)
                {
                    ResourceId = null;
                }
                else
                {
                    if (ResourceId == null)
                        ResourceId = new ResourceId();
                    ResourceId.UserId = value.Value;
                }
            }
        }
        [DataMember(Name="resource_id")]
        private int? resource_id
        {
            get
            {
                return ResourceId == null ? (int?)null : ResourceId.Id;
            }
            set
            {
                if (value == null)
                {
                    ResourceId = null;
                }
                else
                {
                    if (ResourceId == null)
                        ResourceId = new ResourceId();
                    ResourceId.Id = value.Value;
                }
            }
        }
        [DataMember(Name="resource_name")]
        public string ResourceName { get; set; }
    }
