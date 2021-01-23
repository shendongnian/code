    public interface IField {}
    public class Field<T> : IField
    {
        public T value;
        public Field(T value)
        {
            this.value = value;
        }
    }
    // ...
    FieldInfo[] fields = typeof(Action_SetPosition).GetFields();
    for (int a = 0; a < fields.Length; a++)
    {
        if (fields[a] is IField)
        {
            // ...
        }
    }
