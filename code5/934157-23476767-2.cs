    class A : ICloneable 
    {
        public string Message { get; set; }
        public override object Clone()
        {
             A clone = new A();
             
             clone.Message = this.Message;
             return clone;
        }
    }
