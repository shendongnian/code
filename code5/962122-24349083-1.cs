    struct S {
       int f;
       public int F { get { return this.f; } }
       public S SetF(int newVal) {
          var s = new S();
          s.f = newVal;
          return s;
       }
    }
    
    var x = new S();
    x = x.SetF(30);
