    public interface IMessenger { /* nothing special here */ }
    public class MyClass : IMessenger { /* also nothing special */ }
    public static class MessengerExtensions
    {
        public static void ShowMessage(this IMessenger messenger)
        {
            // implement
        }
    }
    ...
    new MyClass().ShowMessage();
