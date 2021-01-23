    public interface IMyMessageListeners<out T>
        where T : IMyMessage
    {
        void Add(IMyMessageReceiver<T> receiver);
    }
    public class MyMessageListeners<T> : IMyMessageListeners<T>
        where T : IMyMessage
    {
        public void Add(IMyMessageReceiver<T> receiver)
        {
    	     // add it to an internal list
        }
    }
