    using System.Linq;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
            var file = @"C:\ConsoleApplication2\bin\Debug\ConsoleApplication2.exe.config";
            var doc = XDocument.Load(file);
            var desc = doc.Root.Descendants("setting")
                .Where(s => s.Attributes()
                    .Any(y => y.Value == "Name")).Descendants("value");
            desc.First().Value = "NewName";
            doc.Save(file);
        }
    }
