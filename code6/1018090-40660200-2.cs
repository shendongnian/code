        public class InventoryEntryListSpecifiedTypeConverter : CsvHelper.TypeConversion.ITypeConverter
        {
            private string indexKey;
            public InventoryEntryListSpecifiedTypeConverter(string indexKey)
            {
                this.indexKey = indexKey;
            }
            public bool CanConvertFrom(Type type)
            {
                return true;
            }
            public bool CanConvertTo(Type type)
            {
                return true;
            }
            public object ConvertFromString(TypeConverterOptions options, string text)
            {
                throw new NotImplementedException();
            }
            public string ConvertToString(TypeConverterOptions options, object value)
            {
                var myValue = value as Dictionary<string, object>;
                if (value == null || myValue.Count == 0) return null;
                return myValue[indexKey] + "";
            }
        }
