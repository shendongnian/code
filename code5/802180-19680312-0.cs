    public class FriendlyNameAttribute : Attribute
    {
        private delegate string dGetString();
        private dGetString dValue;
        public string ResourceName
        {
            get;
            private set;
        }
        public Type ResourceType
        {
            get;
            private set;
        }
        private void CheckValue()
        {
            this.dValue = () => this.ResourceName;
            if (this.ResourceType == null || !this.ResourceType.IsVisible ||  this.ResourceName == null)
            {
                return;
            }
            var property = this.ResourceType.GetProperty(this.ResourceName);
            if (property == null || property.PropertyType != typeof(string))
            {
                return;
            }
            this.dValue = () => (string)property.GetValue(null, null);
        }
        public FriendlyNameAttribute(string resourceName, Type resourceType = null)
        {
            this.ResourceName = resourceName;
            this.ResourceType = resourceType;
            this.CheckValue();
        }
        public string Value
        {
            get
            {
                return this.dValue();
            }
        }
    }
