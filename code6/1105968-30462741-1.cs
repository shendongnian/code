    private void ConvertToObservableCollection(DataTable dataTable)
    {
        var myCollection = new ObservableCollection<MyObject>();
        var myDataView = new DataView(dataTable);
        foreach (DataRowView row in myDataView)
        {
            var obj = new MyObject()
            {
                id = row["id"].ToString(),
                name = row["name"].ToString()
            };
            myCollection.Add(obj);
        }
    }
