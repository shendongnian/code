    public interface class IXX
    {
      int DoIt();
    }
    
    public interface class IFoo
    {
      int Foo(IXX^ ixx);
    }
    
    public interface class IBar
    {
      IFoo^ Bar();
    }
    
    public ref class A : IBar
    {
    private:
      Unmanaged:A* unmanagedA;
    
    public:
      A()
      {
        // Create the unmanaged object that we're wrapping.
        this->unmanagedA = new Unmanaged:A();
      }
    
      A(Unmanaged:A* unmanagedA)
      {
        // Use the passed-in unmanaged object.
        this->unmanagedA = unmanagedA;
      }
      // Clean up the unmanaged object on Dispose (~A) and Finalize (!A).
      ~A() { delete this->unmanagedA; }
      !A() { delete this->unmanagedA; }
    
      IFoo^ Bar()
      {
        // First, get the result from the unmanaged object.
        Unmanaged::FooImpl* unmanagedFoo = this->unmanagedA->Bar();
        // Return it wrapped in a managed wrapper.
        return gcnew FooImpl(unmanagedFoo);
      }
    }
    // (Note: I didn't verify the correctness of this code with a compiler.)
