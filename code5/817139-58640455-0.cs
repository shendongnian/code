    public interface IRepo
    {
        IA<T> Reserve<T>();
    }
    public class FakeRepo : IRepo
    {
        public IA<T> Reserve<T>()
        {
            // your logic here
        }
    }
