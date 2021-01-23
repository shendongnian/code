    class C : A 
    {
      static int a = 42; // static value, initialization is optional 
      static int b {get;set;} // static property ok, with default 0 value
      const int c = 44;
      const string d = "Why?";
      
      public C(int w, int x, string y, string z) : base(a, b, c, d) {...}
      ...
