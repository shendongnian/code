            public static IDictionary<int, string> PrepareAcceptableValues(int filterVal) {
            var values = Enum.GetValues(typeof(myEnum));
            var retval = new List<myEnum>();
            foreach (var value in values) {
                
                try { //if enum value has an attribute type...
                    var assignedFilterProp = value.GetType().GetMember(value.ToString()).First().GetCustomAttribute<FieldAttribute>().FilterProperty;
                    
                    if (assignedFilterProp.Equals(filterVal)) //if enum value has the correct filter property
                        retval.Add((myEnum)value); //add it in
                }
                catch (Exception e) {
                    retval.Add((myEnum)value); //if enum value has no attribute, add it in
                }
            }
            return retval.ToDictionary(i => (int)i, i => i.toString());
