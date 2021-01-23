    public abstract class BaseDTO<T> where T : BaseDTO<T>, new()
    { 
        public static T Empty { get { return new T(); } }
    }
    
    public class ProductDTO : BaseDTO<ProductDTO> { }
