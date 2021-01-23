    class Program
    {
        static void Main(string[] args)
        {
            XMLWorker worker = new XMLWorker();
            //
            string path = @"C:\Users\abc\Desktop\ConsoleApplication1\ConsoleApplication1\XMLFile.xml";
            XmlNodeList nodeList = worker.GetElementsName(path);
            for (int i = 0; i < nodeList.Count; i++)
            Console.WriteLine(nodeList[i].InnerText);
            Console.ReadLine();
        }       
    }
    public class XMLWorker
    {
        public XmlNodeList GetElementsName(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList nodeList = xmlDoc.GetElementsByTagName("email_login");
            return nodeList;
        }
    }
