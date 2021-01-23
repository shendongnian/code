    class Bar {
        //Didn't post this code:
        [ForeignKey("Foo")]
        public int FooId { get; set; }
        public virtual Foo Foo { get; set; }
    }
