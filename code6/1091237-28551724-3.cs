    public interface IMyManager
    {
        //This is optional.
        IDataManager DataManager { get; set; }
        //This method shows how to consume the DataManager.
        public void MyMethod();
    }
