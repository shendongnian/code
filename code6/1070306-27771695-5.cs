        public static bool IsEnumerableOfEnum(Type type)
        {
            return GetEnumerableTypes(type).Any(t => t.IsEnum);
        }
    
