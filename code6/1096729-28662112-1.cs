        public static string FromPHPBase64String(string phpString)
        {
            var bytes = Convert.FromBase64String(phpString);
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                string stringValue = char.ConvertFromUtf32(b);
                sb.Append(sb);
            }
            return sb.ToString();
        }
