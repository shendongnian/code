    class Program
    {
        static void Main(string[] args)
        {
            var s = GetData();
            var r = s.CreateReader();
            while (r.Read())
            {
                if (r.NodeType == XmlNodeType.Element)
                {
                    System.Console.WriteLine(r.Name);
                }
            }
            r.Close();
        }
        private static SqlXml GetData()
        {
            var mem = new MemoryStream();
			//TODO: Deserialize or query data.
            return new SqlXml(mem);
        }
    }
