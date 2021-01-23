    class LocalizedCategoryAttribute : CategoryAttribute {
        public LocalizedCategoryAttribute(string category) : base(category) { }
        protected override string GetLocalizedString(string value)
        {
            // your code here! (treat "value" as the key)
            return base.GetLocalizedString(value);
        }
    }
