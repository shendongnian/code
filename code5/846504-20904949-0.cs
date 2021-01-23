    public class MyNiceRequest : DynamicObject
    {
        private Dictionary<string, string> _dynamicMembers = new Dictionary<string, string>();
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string SomeOptionalField { get; set; }
        public Dictionary<string, string> DynamicMembers
        {
            get { return _dynamicMembers; }
        }
        public override bool TryGetMember(GetMemberBinder binder, out object value)
        {
            string stringValue;
            var isFound = _dynamicMembers.TryGetValue(binder.Name, out stringValue);
            value = stringValue;
            return isFound;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (value is string)
            {
                _dynamicMembers[binder.Name] = (string)value;
                return true;
            }
            return false;
        }
    }
