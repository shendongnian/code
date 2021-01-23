        private int GetInt(object value)
        {
            if (value == null)
            {
                return 0;
            }
            else if (value is double)
            {
                return Convert.ToInt32(value);
            }
            else if (value is string)
            {
                var intValue = 0;
                Int32.TryParse((string)value, out intValue);
                return intValue;
            }
            else
            {
                throw new Exception("Unexpected value type.");
            }
        }
