    [MyInterfaceCheck(typeof(IMyBaseInterface))]
    public interface IMyInterfaceA {...}
    public interface IMyBaseInterface {...}
    public interface IMyInterfaceB : IMyBaseInterface {...}
    public class MyClass : IMyInterfaceA, IMyInterfaceB {...}
