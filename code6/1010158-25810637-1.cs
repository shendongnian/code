    [DelimitedRecord(",")]
    class User : INotifyWrite<User>
    {
        public string Field1;
        public string Field2;
        public string Field3;
        public string Field4;
        public string Field5;
        public void BeforeWrite(BeforeWriteEventArgs<User> e)
        {
        }
        public void AfterWrite(AfterWriteEventArgs<User> e)
        {
            e.RecordLine = e.RecordLine.Trim(',');
        }
    }
