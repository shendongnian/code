    public class Param 
    {
        ...
        public static Param<T> From<T>(string label, ParamType type, T value)
        {
            return new Param<T>() 
            {
                Label = label, 
                Type = type, 
                Value = value 
            }
        }
    }
