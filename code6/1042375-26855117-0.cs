        public bool TryParseNullableInt(string input, out int? output)
        {
            int tempOutput;
            output = null;
            if (string.IsNullOrEmpty(input)) return true;
            if (int.TryParse(input, out tempOutput))
            {
                output = tempOutput;
                return true;
            }
            return false;
        }
