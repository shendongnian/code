    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CsvHelper.TypeConversion;
    
    namespace MyNamespaceInHere {    
        public class StringNormalizer : ITypeConverter {
            public bool CanConvertFrom(Type type) {
                if (type == typeof(string)) return true;
                return false;
            }
            public bool CanConvertTo(Type type) {
                if (type == typeof(string)) return true;
                return false;
            }
            public object ConvertFromString(TypeConverterOptions options, string text) { return normalize(text); }
            public string ConvertToString(TypeConverterOptions options, object value) {
                if (value == null) return string.Empty;
                if (value.GetType() == typeof(string)) {
                    string str = (string)value;
                    return normalize(str);
                }
                return string.Empty;
            }
            public string normalize(string field) {
                // Do stuff in here and return normalized string
                return field + " just a sample";
            }
        }
    }
