        private static string GenerateString(int length, int minCharCode, int maxCharCode)
        {
            var builder = new StringBuilder(length);
            var random = new Random();
            for (var i = 0; i < length; i++)
            {
                builder.Append((char) random.Next(minCharCode, maxCharCode));
            }
            return builder.ToString();
        }
