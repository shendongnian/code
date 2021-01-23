        static void Main(string[] args)
        {
            var str = "<IDP RESULT=\"0\" MESSAGE=\"some message\" ID=\"oaisjd98asdh339wnf\" MSGTYPE=\"Done\"/>";
            var doc = XDocument.Parse(str);
            var element = doc.Element("IDP");
            Console.WriteLine("RESULT: {0}", element.Attribute("RESULT").Value);
            Console.WriteLine("MESSAGE: {0}", element.Attribute("MESSAGE").Value);
            Console.WriteLine("ID: {0}", element.Attribute("ID").Value);
            Console.WriteLine("MSGTYPE: {0}", element.Attribute("MSGTYPE").Value);
            Console.ReadKey();
        }
