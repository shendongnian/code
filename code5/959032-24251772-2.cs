     public class Holder:IXmlSerializable
    {
        public object Data { get; set; }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
        }
        public void WriteXml(XmlWriter writer)
        {
           writer.WriteString(Data.ToString());
        }
    }
    public class DataTableManager
    {
        public static void Save()
        {
            DataTable dataTable = new DataTable("table1");
            DataColumn dataColumn = new DataColumn("Column1",typeof(string));
            DataColumn dataColumn2 = new DataColumn("Column2",typeof(Holder));
            dataTable.Columns.Add(dataColumn);
            dataTable.Columns.Add(dataColumn2);
            dataTable.Rows.Add("ro2", new Holder(){Data = 1});
            Debug.WriteLine(dataTable.Namespace);
            //To file:
            dataTable.WriteXml(@"c:\development\datatable.xml",XmlWriteMode.IgnoreSchema);
            //To string
            StringBuilder stringBuilder = new StringBuilder();
            dataTable.WriteXml(new StringWriter(stringBuilder));
            Debug.WriteLine(stringBuilder.ToString());
        }
    }
