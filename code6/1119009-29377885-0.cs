    class Program
    {
        public static void Main(params string[] args)
        {
            // test.xml contains OPs example content.
            var xdoc = XDocument.Load(@"c:\temp\test.xml"); 
            xdoc.Descendants("LastSyncTime")
               .Where(e => Convert.ToDateTime(e.Element("SyncTime").Value) < DateTime.Now)
               .Remove();
            Console.WriteLine(xdoc);
            xdoc.Save(@"c:\temp\test_filtered.xml");
        }
    }
