        public static List<object> GetDataSource(Type type, bool fillEmptyField = false)
        {
            if (type.IsEnum)
            {
                var data = Enum.GetValues(type).Cast<Enum>()
                           .Select(E => new { Key = (object)Convert.ToInt16(E), Value = ToolsHelper.GetEnumDescription(E) })
                           .ToList<object>();
                var emptyObject = new {Key = default(object), Value = ""};
                if (fillEmptyField)
                {
                    data.Insert(0, emptyObject); // insert the empty field into the combobox
                }
                return data;
            }
            return null;
        }
    
