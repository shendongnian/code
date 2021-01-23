    public class TypeOfRes
        {
            public object Object { get; set; }
    
            public Type TypeOf
            {
                get { return Object == null ? null : Object.GetType(); }
            }
        }
