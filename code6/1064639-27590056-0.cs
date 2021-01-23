    class Program
    {
        static void Main(string[] args)
        {
            var layers = new List<ILayer<object>>();
            layers.Add(new Layer<string>()); // It is covariance so we can only use reference types.
        }
    }
    public interface ILayer<out T>
    {
        void CreateCells();
        ICell<T>[] GetCells();
    }
    public class Layer<T> : ILayer<T>
    {
        public void CreateCells()
        {
            
        }
        public ICell<T>[] GetCells()
        {
            return new[] { new Cell<T>() };
        }
    }
    public interface ICell<out T>
    { }
    public class Cell<T> : ICell<T>
    { }
