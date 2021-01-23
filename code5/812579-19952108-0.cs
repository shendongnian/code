    public class Test<T>
    {
        public T GenericProperty { get; set; }
        public override string ToString()
        {
            string ret;
            if ( GenericProperty is IEnumerable)
            {
                IEnumerable en = GenericProperty as IEnumerable;
                ret = String.Join(",", en.Cast<object>());
            }
            else
            {
                ret = GenericProperty.ToString();
            }
            return ret;
        }
    }
