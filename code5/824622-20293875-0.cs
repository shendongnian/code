        public object Convert(string toConvert, Type typeToConvert)
        {
            if(typeToConvert is string)
            {
                return toConvert;
            }
            else if(typeToConvert is bool)
            {
                bool convertedOutput;
                if (bool.TryParse(toConvert, out convertedOutput))
                {
                    return convertedOutput;
                }
            }
            else if (typeToConvert is Int64 || typeToConvert is Int32 || typeToConvert is Int16)
            {
                Int64 convertedOutput;
                if (Int64.TryParse(toConvert, out convertedOutput))
                {
                    return convertedOutput;
                }
            }
            // additional converts here...
            return string.Empty;
        }
