    public class MyObject
    {
        protected MyObject(MyObject other)
        {
            this.Prop1=other.Prop1;
            this.Prop2=other.Prop2;
        }
        public object Prop1 { get; set; }
        public object Prop2 { get; set; }
    }
    public class MyObjectSearch : MyObject
    {
        public double Distance { get; set; }
        public MyObjectSearch(MyObject obj)
             : base(obj)
        {
            this.Distance=0;
        }
        public MyObjectSearch(MyObjectSearch other)
             : base(other)
        {
            this.Distance=other.Distance;
        }
    }
