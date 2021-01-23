    class Program {
        static void Main(string[ ] args) {
            XDocument doc = XDocument.Load("D:\\file.xml"); //example file
            doc.Root.SwitchAndRemove("Customer1");
            doc.Save("D:\\file.xml");
        }
    }
    public static class Utilities {
        public static void SwitchAndRemove(this XElement customers, XName name) {
            var x = customers.Descendants().Where(e => e.Name == name).Select((element, index) => new { element, index }).Single();
            int count = 0;
            XElement temp = x.element;
            foreach (XElement el in customers.Nodes()) {
                if (count == x.index + 1) {
                    temp.RemoveAll();
                    temp.Add(el.Descendants().ToArray());
                    temp = el;
                }
                else
                    count++;
            }
            temp.Remove();
        }
    }
