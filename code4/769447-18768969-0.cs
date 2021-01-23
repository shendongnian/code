        private void ExportDataTable(SqlCeCommand cmd, SqlCeConnection conn)
        {
            cmd.Connection = conn;
            System.Data.DataTable table = new System.Data.DataTable();
            table.Locale = CultureInfo.InvariantCulture;
            table.Load(cmd.ExecuteReader());
            StreamWriter xmlDoc = new StreamWriter("Output.xml");
            table.WriteXml(xmlDoc);
        }
 
