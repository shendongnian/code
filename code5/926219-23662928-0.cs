    public class ApiAllowableValues2Attribute : ApiAllowableValuesAttribute
    {
        public ApiAllowableValues2Attribute(string name, Type enumType)
            : base(name)
        {
            List<string> values = new List<string>();
            var enumTypeValues = Enum.GetValues(enumType);
            // loop through each enum value
            foreach (var etValue in enumTypeValues)
            {
                // get the member in order to get the enumMemberAttribute
                var member = enumType.GetMember(
                    Enum.GetName(enumType, etValue)).First();
                // get the enumMember attribute
                var enumMemberAttr = member.GetCustomAttributes(
                    typeof(System.Runtime.Serialization.EnumMemberAttribute), true).First();
                // get the enumMember attribute value
                var enumMemberValue = ((System.Runtime.Serialization.EnumMemberAttribute)enumMemberAttr).Value;
                values.Add(enumMemberValue);
            }
            Values = values.ToArray();
        }
    }
