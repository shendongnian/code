        public abstract class CommandParameter
        {
            public string ParameterName { get; set; }
            public virtual object ParameterValue { get; }
            public virtual string ParameterType { get; }
        }
        public class CommandParameter<T>:CommandParameter
        {
            public T Value { get; set; }
            public override object ParameterValue
            {
                get
                {
                    return Value;
                }
            }
            public override string ParameterType
            {
                get
                {
                    return typeof(T).Name;
                }
            }
        }
