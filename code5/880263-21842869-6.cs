    public static class NestedArray
    {
        public static Array Create<T>(params int[] lengths)
        {
            Type arrayType = typeof(T);
            for (int i = 0; i < lengths.Length - 1; i++)
                arrayType = arrayType.MakeArrayType();
            return CreateArray(arrayType, lengths[0], lengths.Skip(1).ToArray());
        }
        private static Array CreateArray(Type elementType, int length, params int[] subLengths)
        {
            Array array = Array.CreateInstance(elementType, length);
            if (subLengths.Length > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    Array nestedArray = CreateArray(elementType.GetElementType(), subLengths[0], subLengths.Skip(1).ToArray());
                    array.SetValue(nestedArray, i);
                }
            }
            return array;
        }
    }
    
