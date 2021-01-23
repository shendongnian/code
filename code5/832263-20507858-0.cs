    public class MyObject : DatabaseObject
    {
        public string FieldX
        {
            get { return GetValue(() => FieldX); }
            set { SetValue(() => FieldX, value); }
        }
    
        public int FieldY
        {
            get { return GetValue(() => FieldY); }
            set { SetValue(() => FieldY, value); }
        }
    }
    public class DatabaseObject
    {
        public T GetValue<T>(Expression<Func<T>> field)
        {
             string fieldName = GetFieldName(field);
             // Code that actually gets the right value
        }
    
        public void SetValue<T>(Expression<Func<T>> field, T value)
        {
             string fieldName = GetFieldName(field);
             // Code that actually sets the value in the right place
        }
        private static string GetFieldName<T>(Expression<Func<T>> field)
        {
            return ((MemberExpression)field.Body).Member.Name;
        }
    }
