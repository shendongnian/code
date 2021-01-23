    public abstract class A1;
    public abstract class A2;
    public abstract class B : A2;
    public class C : A1, A2; // invalid
    public class D : B; // valid
