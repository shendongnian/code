    public interface IInputDescription { }
    public class InputClass1 : IInputDescription { .. }
    public class InputClass2 : IInputDescription { .. }
    public class ErrorClass { .. } // This example class does not implement IInputDescription
    
    public void SomeMethod(IInputDescription value) { .. }
    SomeMethod(new InputClass2()); // Compiles
    SomeMethod(new ErrorClass()); // Compile error
