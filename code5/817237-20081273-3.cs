    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""key1"" : ""value1"",
                ""key2"" : ""value2"",
                ""int"" : 5,
                ""bool"" : true,
                ""decimal"" : 3.14,
                ""punct"" : ""x+y=z""
            }";
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                if (!string.IsNullOrEmpty(kvp.Key) && !string.IsNullOrEmpty(kvp.Value))
                {
                    if (sb.Length > 0) sb.Append('&');
                    sb.Append(HttpUtility.UrlEncode(kvp.Key));
                    sb.Append('=');
                    sb.Append(HttpUtility.UrlEncode(kvp.Value));
                }
            }
            var postDataString = sb.ToString();
            Console.WriteLine(postDataString);
        }
    }
