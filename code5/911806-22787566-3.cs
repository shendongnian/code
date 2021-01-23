    public static class ExtensionMethods
    {
        public IEnumerable Without(this IEnumerable enumeration, object toLeaveOut)
        {
            foreach (var e in enumeration)
            {
                if (!object.ReferenceEquals(e, toLeaveOut))
                {
                    yield return e;
                }
            }
        }
    }
