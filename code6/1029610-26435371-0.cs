        public const string Property = "Base";
        public virtual string InstanceProperty
        {
            get
            {
                return (string)this.GetType().GetField("Property", BindingFlags.Public | BindingFlags.Static).GetValue(null); 
            }
        }
