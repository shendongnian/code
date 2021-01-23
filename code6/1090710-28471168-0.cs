    public class MyClass {
      public void Dispose() {
        ...
      }
    }
    ...
    // using() emulation
    MyClass m = null;
    try {
      m = new MyClass();
      ...
    }
    finally {
      if (m != null)
        m.Dispose();
    }
