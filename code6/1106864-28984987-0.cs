    public interface IMyClass
    {
        object this[int index]
        {
            get; set;
        }
    }
    public class MyClass : IMyClass
    {
        public string this[int index]
        {
            get
            {
                return "";
            }
            set
            {
            }
        }
        object IMyClass.this[int index]
        {
            get
            {
                return "";
            }
            set
            {
            }
        }
    }
