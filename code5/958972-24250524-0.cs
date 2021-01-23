    public interface ILayer
    {
        U GetValue<U>(int x, int y);
    }
    
    public class Layer<T> : ILayer
    {
        public T[,] Matrix { get; set; }
    
        U ILayer.GetValue<U>(int x, int y)
        {
            return (U) (object) Matrix[x, y];
        }
    } 
