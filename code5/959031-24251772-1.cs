    public class DataTableManager
    {
        public static void Save()
        {
            DataTable dataTable = new DataTable("table1");
            DataColumn dataColumn = new DataColumn("Column1",typeof(string));
            DataColumn dataColumn2 = new DataColumn("Column2",typeof(long));
            dataTable.Columns.Add(dataColumn);
            dataTable.Columns.Add(dataColumn2);
            dataTable.Rows.Add("ro1", 1);
            dataTable.Rows.Add("ro2", 2);
            dataTable.WriteXml(@"c:\test1\datatable.xml",XmlWriteMode.IgnoreSchema);
        }
    }
