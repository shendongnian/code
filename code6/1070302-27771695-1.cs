        public static bool IsEnumerableOfEnum(Type type)
        {
            var enumerableType = GetEnumerableType(type);
            return enumerableType != null && enumerableType.IsEnum;
        }
    
