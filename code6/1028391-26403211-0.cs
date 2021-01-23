    public class A
      {
        public string P { get; set; }
        public virtual string VirtualString { get; set; }
      }
    
      public class A1 : A
      {
        public string P1 { get; set; }
    
        public override string VirtualString
        {
          get { return P1; }
          set { P1 = value; }
        }
      }
    
      public class A2 : A
      {
        public string P2 { get; set; }
    
        public override string VirtualString
        {
          get { return P2; }
          set { P2 = value; }
        }
      }
