        public static string FixGermanQuotationMarks(string input)
        {
            var pattern = @"""([^""]*)""";
            return Regex.Replace(input, pattern, @"„$1“");
        }
