    class ABC {
      int A { get; set; }
      int B { get; set; }
      int C { get; set; }
    }
    
    class StoreStruct {
      ABC ABC1 { get; set; }
      ABC ABC2 { get; set; }
      ABC ABC3 { get; set; }
      public StoreStruct {
        ABC1 = new ABC();
        ABC2 = new ABC();
        ABC3 = new ABC();
      }
    }
