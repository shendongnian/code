    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Criteria c)
        {
            var sourceType = typeof(T);
            var propertyMember = sourceType.GetProperty(c.Property);
            Func<string, bool> predicate = null;
            switch (c.Operator)
            {
                case "equal":
                    predicate = (v) => v == c.Value;
                    break;
                // other operators
                default:
                    throw new ArgumentException("Unsupported operator.");
            }
            return source.Where(v => predicate((string)propertyMember.GetMethod.Invoke(v, null)));
        }
    }
