        static void Main(string[] args)
        {
            string value = ReadVMSettings("EN2008", "guest", "browser");
        }
        public static string ReadVMSettings(string systemName, string section, string name)
        {
            string systemsFilePath = @"C:\Text.xml";
            Console.WriteLine("Systems.xml path is: " + systemsFilePath);
            XDocument systemXML = XDocument.Load(systemsFilePath);
            var result = from vm in systemXML.Root.Descendants("VM")
                         where vm.Attribute("name").Value == systemName
                         select vm.Element(section).Element(name).Attribute("value").ToString();
            return result.FirstOrDefault().ToString();
        }
