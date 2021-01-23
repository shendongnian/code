    public class TestModel
    {
        public ChildModel1 ChildModel1 { get; set; }
        public ChildModel2 ChildModel2 { get; set; }
       
        public TestModel()
        {
            ChildModel1 = new ChildModel1();
            ChildModel1 = new ChildModel1();
        }
    }
