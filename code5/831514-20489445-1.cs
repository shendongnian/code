    private System.ComponentModel.BindingList<T> getRecordsOfType<T>()
    {
        System.ComponentModel.BindingList<T> recordList = new System.ComponentModel.BindingList<T>();
        var records = session.Query.All<T>();
        recordList = new System.ComponentModel.BindingList<T>(records.ToList<T>());
        return recordList;
    }
