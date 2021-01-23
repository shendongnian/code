    // Your code
    private static DataTable ToDataTable<TSource>(this IList<TSource> data)
    {
        foreach (TSource item in data)
        {
            if (!(item is StringConvertible))
            {
                continue;
            }
            
            StringConvertible value = (StringConvertible)item;
            switch (value)
            {
                case "Name":
                    value = "John";
                    break;
            }
        }
    }
    // ...
    public abstract class StringConvertible
    {
        private string _internalValue;
        protected StringConvertible(string value)
        {
            this._internalValue = value;
        }
        public static implicit operator string(StringConvertiblesource)
        {
            return source.ToString();
        }
        public static implicit operator StringConvertible(string value)
        {
            return new StringConvertible(value);
        }
        public override string ToString()
        {
            return this._internalValue;
        }
    }
