    private void ConvertToObservableCollection(DataTable dataTable)
    {
        var myCollection = new ObservableCollection<MyObject>();
        foreach (var row in MyDataTable.Rows)
        {
            var obj = new MyObject()
            {
                id = (int)row["id"],
                name = (string)row["name"]
            };
            myCollection.Add(obj);
        }
    }
