    public interface IBaseClass
    {
        int Id { get; set; }
        object Value { get; set; }
    }
    public abstract class BaseClass<T>
    {
        public int Id { get; set; }
        public T Value { get; set; }
    }
    public class ClassInt : BaseClass<int>, IBaseClass
    {
        object IBaseClass.Value
        {
            get { return Value; }
            set
            {
                // put some type checking and error handling here
                Value = (int)value;
            }
        }
    }
