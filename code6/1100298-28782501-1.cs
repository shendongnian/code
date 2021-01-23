    class TestA
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public string Category { get; set; }
    
        public TestA(int id, int procid, string category)
        {
            this.Id = id;
            this.ProductID = procid;
            this.Category = category;
        }
    
        public TestA() { }
    
        public override bool Equals(object obj)
        {
            TestA secondObj = obj as TestA;
    
            return this.ProductID == secondObj.ProductID && this.Category == secondObj.Category;
        }
    }
