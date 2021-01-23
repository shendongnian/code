    internal class Program
    {
        private static void Main()
        {
            //var mappings = Directory.EnumerateFiles("ssis","*.dtsx").Select(x=>ParseDtsx(Path.GetFileName(x).ToString())).ToList();
            var list = new MappingsXml
            {
                Mappings =
                    Directory.EnumerateFiles("ssis", "*.dtsx")
                        .Select(x => ParseDtsx((Path.GetFileName(x) ?? "").ToString()))
                        .ToList()
            };
            var xsSubmit = new XmlSerializer(typeof (MappingsXml));
    
            using (var file = new StreamWriter(
                @"AutoRemoteMappingXmls.xml"))
            {
                xsSubmit.Serialize(file, list);
            }
        }
    }
