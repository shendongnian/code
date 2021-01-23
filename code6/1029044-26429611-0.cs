        private static Regex InnerValues = new Regex(@"(?<=<(.*?>)).*?(?=</\1)",RegexOptions.Compiled);
        private static XmlDocument LoadInvalidDocument(string path)
        {
            XmlDocument result = new XmlDocument();
            string content = File.ReadAllText(path);
           
            var matches = InnerValues.Matches(content);
            foreach (Match match in matches)
            {
                content = content.Replace(match.Value,  HttpUtility.HtmlEncode(match.Value));
            }
            result.LoadXml(content);
            return result;
        }
