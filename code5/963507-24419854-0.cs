    public class MultiKeyDictionary : Dictionary<EntityID, string>
    {
        private Dictionary<string, EntityID> _handleLookup = new Dictionary<string, EntityID>();
        public Dictionary<string, EntityID> HandleLookup
        {
            get { return _handleLookup; }
            set { _handleLookup = value; }
        }
        public string this[string handle]
        {
            get
            {
                EntityID id = this.HandleLookup[handle];
                return base[id];
            }
        }
        public void Add(EntityID id, string handle, string value)
        {
            base.Add(id, value);
            this.HandleLookup.Add(handle, id);
        }
    }
