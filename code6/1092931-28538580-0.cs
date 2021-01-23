    class Foo
    {
        public int ID { get; set; }
    
        public string Data { get; set; }
    
        public int firstFkID { get; set; }
    
        public int secondFkID { get; set; }
    
        //[ForeignKey("firstFkID")] <- remove this while using fluent api
        public virtual Foo firstFk { get; set; }
    
        //[ForeignKey("secondFkID")] <- remove this while using fluent api
        public virtual Foo secondFk { get; set; }
    }
