	using (XmlLogfileStream logfileStream = new XmlLogfileStream(filename))
    {
        DataSet ds = new DataSet();
        DataTable dataTable = new DataTable("LogInfo");
        dataTable.Columns.Add("Time", typeof(string));
        dataTable.Columns.Add("Message", typeof(string));
        ds.Tables.Add(dataTable);
        ds.ReadXml(logfileStream);
        dgLogView.ItemsSource = dataTable.DefaultView;
    }
