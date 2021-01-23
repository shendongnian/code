    class Program {
        static void Main(string[ ] args) {
            XDocument doc = XDocument.Load("D:\\file.xml"); //example file
            doc.SwitchElements("Customer3", "Customer2");
            doc.Save("D:\\file.xml");
        }
    }
    public static class Utilities{
        public static void SwitchElements(this XDocument doc, XName name1, XName name2){
            XElement el1 = doc.Descendants().Where(x => x.Name == name1).Single();
            var temp = el1.Descendants().ToArray();
            el1.RemoveAll();
            XElement el2 = doc.Descendants().Where(x => x.Name == name2).Single();
            el1.Add(el2.Descendants());
            el2.RemoveAll();
            el2.Add(temp);
        }
    }
