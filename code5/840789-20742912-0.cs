    public partial class MyModelCLass : IDataErrorInfo
    {
        public string this[string columnName]
        ...
        public string Error { get; private set; }
        ...
    }
