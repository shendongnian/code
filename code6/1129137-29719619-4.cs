    internal static class ExtensionMethods
    {
        public static String Join<T>(this IEnumerable<T> enumerable)
        {
            StringBuilder sb = new StringBuilder();
            JoinInternal(enumerable, sb, true);
            return sb.ToString();
        }
        private static bool JoinInternal(IEnumerable enumerable, StringBuilder sb, bool first)
        {
            foreach (var item in enumerable)
            {
                var castItem = item as IEnumerable;
                if (castItem != null)
                {
                    first = JoinInternal(castItem, sb, first);
                }
                else
                {
                    if (!first)
                    {
                        sb.Append(",");
                    }
                    else
                    {
                        first = false;
                    }
                    sb.Append(item);
                }
            }
            return first;
        }
    }
