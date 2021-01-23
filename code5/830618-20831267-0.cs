    Hashtable _hash = new Hashtable();
        private static DataTable CreateTable<T>(List<T> List)
        {
            DataTable OutTable = new DataTable();
            using (var reader = ObjectReader.Create(List))
            {
                OutTable.Load(reader);
            }
            return OutTable;
        }
        private void c1FlexGrid1_GetUnboundValue(object sender, C1.Win.C1FlexGrid.UnboundValueEventArgs e)
        {
            DataRowView drv = (DataRowView)c1FlexGrid1.Rows[e.Row].DataSource;
            e.Value = _hash[e.Row.ToString() + "|" + e.Col.ToString()];
        }
        private void c1FlexGrid1_SetUnboundValue(object sender, C1.Win.C1FlexGrid.UnboundValueEventArgs e)
        {
            DataRowView drv = (DataRowView)c1FlexGrid1.Rows[e.Row].DataSource;
            _hash[e.Row.ToString() + "|" + e.Col.ToString()] = e.Value;
        }
