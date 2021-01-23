    public class Test
    {
        private Test(string strName, string strID, string StartDate, string EndDate, string strParentId, Test Cat_parent)
        {
            ParentId = strParentId;
            Name = strName;
            ID = strID;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            Parent = Cat_parent;
        }
        public string ID { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ParentId { get; set; }
        Test Parent { get; set; }
    }
    public class TestsCollection : ObservableCollection<Test>
    {
        // looks llike you try to implement here a singelton:
        static TestsCollection instance = null;
        public static TestsCollection GetWarehouseData(DataTable dt)
        {
            if (instance == null)
            {
                instance = new TestsCollection();
            }
            // here add your conversion code but:
            // you must work on the same instance that you bound before that,
            // dont create a new one each time, as it will not the one that you bound to your GUI
            return instance;
        }
    }
