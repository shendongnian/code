    public interface IParameter
    {
        string Index { get; set; }
        Type ParameterType { get; }
    }
    public class Parameter<T> : IParameter
    {
        public string Index { get; set; }
        public T Value { get; set; }
        public Type ParameterType
        {
            get
            {
                return typeof(T);
            }
        }
    }
    class ParameterModel
    {
        public List<IParameter> Parameters { get; }
    }
