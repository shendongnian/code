    public interface ILayer
        {
        }
    
        public class Layer<T> : ILayer
        {
            public T[,] Matrix { get; set; }
    
            public T GetValue(int x, int y)
            {
                return Matrix[x, y];
            }
        }
    
        public static class LayerExtensions
        {
            public static U GetValue<U>(this ILayer layer, int x, int y)
            {
                return ((Layer<U>)layer).GetValue(x, y);
            }
        }
