    public static class EnumHelpers<TTarget>
    {
        static EnumHelpers()
        {
            Dict = Enum.GetNames(typeof(TTarget)).ToDictionary(x => x, x => (TTarget)Enum.Parse(typeof(TTarget), x), StringComparer.OrdinalIgnoreCase);
        }
        private static readonly Dictionary<string, TTarget> Dict;
        public static TTarget Convert(string value)
        {
            return Dict[value];
        }
    }
