    public abstract class MessengerBase
    {
        public void ShowMethod() { /* implement */ }
    }
    public class MyClass : MessengerBase {}
    ...
    new MyClass().ShowMethod();
