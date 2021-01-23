    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using Newtonsoft.Json.Linq;
    class Program
    {
        private static void Main()
        {
            var encoding = Encoding.UTF8;
            var testJson = new JObject
                {
                    new JProperty(
                        "AQuote",
                        string(new[] { (char)0x201c }))
                };
            JObject roundTripped;
            using (var m = new MemoryStream())
            {
                using(var writer = new StreamWriter(m, encoding))
                {
                    var reader = new StreamReader(m, encoding);
                    writer.Write(testJson.ToString());
                    writer.Flush();
                    m.Seek(0, SeekOrigin.Begin);
                    roundTripped = JObject.Parse(reader.ReadToEnd());
                }
            }
        }
        Debug.Assert(
            string.Equals(
                testJson["AQuote"].Value<string>(),
                roundTripped["AQuote"].Value<string>()),
            "These strings should be equal.");
    }
