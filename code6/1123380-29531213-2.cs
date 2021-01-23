    internal class StringConvertible
    {
        public static implicit operator string(StringConvertible value)
        {
            return value.StringValue;
        }
        public static implicit operator StringConvertible(string value)
        {
            return new StringConvertible
            {
                StringValue = value
            };
        }
        public virtual string StringValue { get; set; }
    }
    // ...
    private static DataTable ToDataTable<TSource>(this IList<TSource> data)
    {
        for (int index = 0; index < data.Count; index++)
        {
            if (!typeof(TSource).IsAssignableFrom(typeof(StringConvertible)))
            {
                continue;
            }
            StringConvertible value = data[index] as StringConvertible;
            switch (value)
            {
                case "Name":
                    value.StringValue = "John";
                    break;
            }     
        }
        // ...
    }
