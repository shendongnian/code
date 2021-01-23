    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""MobileSiteContents"": {
                    ""au/en"": [
                        ""http://www.url1.com"",
                        ""http://www.url2.com"",
                    ],
                    ""cn/zh"": [
                        ""http://www.url2643.com"",
                    ]
                }
            }";
            foreach (MobileSiteContentsContentSectionItem item in Parse(json))
            {
                Console.WriteLine(item.Culture);
                foreach (string url in item.Urls)
                {
                    Console.WriteLine("  " + url);
                }
            }
        }
        public static IEnumerable<MobileSiteContentsContentSectionItem> Parse(string json)
        {
            return JObject.Parse(json)["MobileSiteContents"]
                .Children<JProperty>()
                .Select(prop => new MobileSiteContentsContentSectionItem()
                {
                    Culture = prop.Name,
                    Urls = prop.Value.ToObject<string[]>()
                })
                .ToList();
        }
        public class MobileSiteContentsContentSectionItem : ContentSectionItem
        {
            public string[] Urls { get; set; }
        }
        public abstract class ContentSectionItem
        {
            public string Culture { get; set; }
        }
    }
