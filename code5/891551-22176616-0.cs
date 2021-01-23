        public static string MyJoin(this IEnumerable<string> strings)
        {
            return string.MyJoin(Environment.NewLine, strings);
        }
        public static string MyJoin(this IEnumerable<object> items)
        {
            if (items.All(x => x is string))
                return items.Cast<string>().MyJoin();
            if (items.All(x => x is IEnumerable<object>))
                return items.Cast<IEnumerable<object>>().Select(x => x.MyJoin()).MyJoin();
            throw new InvalidOperationException("The argument was not a nested enumerable of strings.");
        }
