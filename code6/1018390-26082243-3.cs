    public interface ICallback
    {
        void OnSuccess<T>(T data);
        void OnFailure(Exception exception);
    }
    public class ToDoTask<T>
    {
        private int someInt;
        public string StringProperty { get; set; }
        public ICallback Callback { get; private set; }
    }
