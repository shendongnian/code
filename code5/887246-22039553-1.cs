    class Program {
        static void Main(string[ ] args) {
            XDocument doc = XDocument.Load("D:\\file.xml"); //example file
            doc.SwitchAndRemove("Customer2", "Customer4"); //warning: in your xml there is no <Customer3>...</Customer3>
            doc.Save("D:\\file.xml");
        }
    }
    public static class Utilities {
        public static void SwitchAndRemove(this XDocument doc, XName name1, XName name2) {
            XElement el1 = doc.Descendants().Where(x => x.Name == name1).Single();
            el1.RemoveAll();
            XElement el2 = doc.Descendants().Where(x => x.Name == name2).Single();
            el1.Add(el2.Descendants());
            el2.Remove();
        }
    }
