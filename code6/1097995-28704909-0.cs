    public class Base {
      internal Base() { }
    }
    public interface IBase { }
    public sealed class Class1 : Base, IBase {
      ...
    }
    public sealed class Class2 : Base, IBase {
      ...
    }
    public T GetFoo<T>() where T : Base, IBase {
      ...
    }
