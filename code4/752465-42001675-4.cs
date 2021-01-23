    using System;
    using System.Collections.Generic;
    public static class Extension
    {
        public static bool HasDuplicate<T>(
            this IEnumerable<T> source,
            out T firstDuplicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            var checkBuffer = new HashSet<T>();
            foreach (var t in source)
            {
                firstDuplicate = t;
                if (!checkBuffer.Add(firstDuplicate))
                {
                    return true;
                }
            }
            firstDuplicate = default(T);
            return false;
        }
    }
