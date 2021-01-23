        // http://msdn.microsoft.com/en-us/library/ebza6ck1.aspx
        String NormalizeString(String value)
        {
            if (!value.IsNullOrEmpty())
            {
                var newStringBuilder = new StringBuilder();
                newStringBuilder.Append(value.Normalize(NormalizationForm.FormKD)
                                                .Where(x => x < 128)
                                                .ToArray());
                return newStringBuilder.ToString();
            }
            return value;
        }
