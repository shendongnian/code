    public static class BooleanBoxExtensions
    {
        private static readonly object BoxedTrue = true;
        private static readonly object BoxedFalse = false;
        public static object BoxCheaply(this bool value)
        {
            return value ? BoxedTrue : BoxedFalse;
        }
    }
