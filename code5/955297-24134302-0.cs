    public static class SapToDataExtensionClass
    {
        public static Dictionary<string,string> ToDictionary(this IRfcStructure stru)
        {
            Dictionary<string,string> dict = new Dictionary<string, string>();
            for (int i = 0; i < stru.Metadata.FieldCount; i++)
            {
                dict.Add(stru.Metadata[i].Name , stru.GetString(i) );  
            }
      
            return dict;
        }
        public static DataTable GetDataTable(this IRfcTable i_Table)
        {
            DataTable dt = new DataTable();
            dt.GetColumnsFromSapTable(i_Table);
            dt.FillRowsFromSapTable(i_Table);
            return dt;
        }
        public static void FillRowsFromSapTable(this DataTable i_DataTable, IRfcTable i_Table)
        {
            foreach (IRfcStructure tableRow in i_Table)
            {
                DataRow dr = i_DataTable.NewRow();
                dr.ItemArray = tableRow.Select(structField => structField.GetValue()).ToArray();
                i_DataTable.Rows.Add(dr);
            }
        }
        public static void GetColumnsFromSapTable(this DataTable i_DataTable, IRfcTable i_SapTable)
        {
            var DataColumnsArr = i_SapTable.Metadata.LineType.CreateStructure().ToList().Select
            (structField => new DataColumn(structField.Metadata.Name)).ToArray();
            i_DataTable.Columns.AddRange(DataColumnsArr);
        }
    }
