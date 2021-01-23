        private static DataTable getBasicDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Clear();
            dataTable.Columns.Add("customerID");
            dataTable.Columns.Add("firstName");
            dataTable.Columns.Add("lastName");
            dataTable.Columns.Add("showsNumber");
            dataTable.Columns.Add("visitNumber");
            dataTable.Columns.Add("cancellation");
            return dataTable;
        }
