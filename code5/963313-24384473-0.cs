    using System.Xml.Serialization;
    using System.IO;
    namespace DemoApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                NewDataSet objNewDataSet = new NewDataSet();
                Table objTable = new Table();
                objTable.Conact = "Hello";
                objNewDataSet.Table1 = objTable;
                StreamWriter objStream = new StreamWriter("C:\\Users\\Nirav Kamani\\Desktop\\abc.xml");
                XmlSerializer objXmlSerializer = new XmlSerializer(typeof(NewDataSet));
                objXmlSerializer.Serialize(objStream, objNewDataSet);
        }
    }
