    class Box {
        public object Value { get; set; }
        public string Display { get; set; }
 
        public override void ToString() { return Display; }
    }
