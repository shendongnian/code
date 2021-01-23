    namespace App
    {
        public class Defaults
        {
            private static Dictionary<Type, Func<object>> _initializer = new Dictionary<Type, Func<object>>
            {
                {typeof (FieldModel), () => new FieldModel {X = "X"}},
                {typeof (TableModel), () => new TableModel {Y = "Y", Z = "Z"}}
            };
    
            public static Dictionary<Type, Func<object>> Initializer
            {
                get { return _initializer; }
                set { _initializer = value; }
            }
        }
    }
