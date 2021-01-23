    public Model<T> Construct<T>(T param) where T : IModelable
    {
        var n = new Model<T> {Resource = param};
        return n;
    }
    public class Model<T> : IModel<T> where T : IModelable
    {
        public T Resource { get; set; }
    }
    public interface IModel<out T> where T : IModelable
    {
        T Resource { get; }
    }
