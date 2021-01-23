    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class FilterAttribute : Attribute
    {
        public enum eMultiselectComperer
        {
            Unspecified = 0, 
            Or,
            And
        }
    
        public bool IsMultiselect { get; set; }
    
        public eMultiselectComperer MultiselectComperer { get; set; }
    }
