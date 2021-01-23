    class A {
      // This method can be called within derived classes only
      protected void ProtectedA() {...}
      // This method can be called within classes that are in the same namespace
      internal void InternalA() {...} 
      // This method can be called either within derived classes only or
      // within classes that are in the same namespace
      protected internal void InternalOrProtectedA() {...} 
    }
    
    class B: A {
      protected void ProtectedB() {
        // You can call A.ProtectedA() here since B is derived from A
      }
    }
    
    class Program {
      static void Main(string[] args)
        // You can NOT call A.ProtectedA() here since B is NOT derived from A
        // But you can call
        //   A.InternalA() since classes Program and A are in the same namespace
        //   A.InternalOrProtectedA() on the same reason
      }
    }
