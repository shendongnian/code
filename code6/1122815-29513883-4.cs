    public static class StringUtilities
    {
        public static string HtmlEncode(string input, Encoding source, Encoding destination)
        {
            var sourceChars = HttpUtility.HtmlEncode(input).ToArray();
            var sb = new StringBuilder();
            foreach (var sourceChar in sourceChars)
            {
                byte[] sourceBytes = source.GetBytes(new[] { sourceChar });
                char destChar = destination.GetChars(sourceBytes).FirstOrDefault();
                if (destChar != sourceChar)
                    sb.AppendFormat("&#{0};", (int)sourceChar);
                else
                    sb.Append(sourceChar);
            }
            return sb.ToString();
        }
    }
