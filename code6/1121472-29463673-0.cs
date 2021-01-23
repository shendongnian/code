    class Program
    {
        static string my_xml = 
            "<Messages> " +
            "    <Exceptions />" +
            "    <ValidationIssues>" +
            "        <ValidationMessage Message=\"The Customer Communication requires a value for Search Phone or Email.\" FriendlyMessage=\"\\\" />  " +
            "    </ValidationIssues>" +
            "</Messages>";
        public static void Main(params string[] args)
        {
            var doc = XDocument.Parse(my_xml, LoadOptions.PreserveWhitespace);
            var messages = doc
                .Descendants("ValidationMessage")
                .Where(x => x.Attribute("Message") != null)
                .Select(x => x.Attribute("Message").Value);
            Console.WriteLine(string.Join(Environment.NewLine, messages));
            Console.ReadLine();
        }
    }
