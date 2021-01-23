    internal sealed class A: ICloneable {
      // Let it be List, OK?
      // It looks, that you don't need "set" here 
      public List<B> CollectionB { get; }
    
      public int Int1 { get; set; }
      public int Int2 { get; set; }
      public int Int3 { get; set; }
      public int Int4 { get; set; }
    
      // It's more convenient to return A, not Object
      // That's why explicit interface implementation    
      Object ICloneable.Clone() {
        return this.Clone();
      }
    
      public A Clone() {
        A result = new A();
    
        result.Int1 = Int1; 
        result.Int2 = Int2; 
        result.Int3 = Int3; 
        result.Int4 = Int4; 
    
        // Deep copy: you have to clone each B instance:
        foreach(B item in CollectionB)
          result.CollectionB.Add(item.Clone()); // <- thanks for explicit inteface impl. it ret B
    
        return result;
      }
    }
    
    internal sealed class B: ICloneable {
        // Let it be List
        // It looks, that you don't need "set" here 
        public List<Bitmap> SomeBitmaps { get; }
    
        public int Int1 { get; set; }
        public int Int2 { get; set; }
        //. . .
        //etc.
    
        // It's more convenient to return B, not Object
        // That's why explicit interface implementation    
        Object ICloneable.Clone() {
          return this.Clone();
        }
    
        // It's more convenient to return B, not Object    
        public B Clone() {
          B result = new B();
    
          result.Int1 = Int1; 
          result.Int2 = Int2; 
          // ...
          //etc.
    
          // Deep copy: you have to create new bitmaps here
          foreach(Bitmap source in SomeBitmaps) 
            result.SomeBitmaps(new Bitmap(source));
    
          return result; 
        }
    }
