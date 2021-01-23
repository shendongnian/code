    class MyGenericClass<T>
    {
        public static T GetValue(T[,] array, params int[] indices) 
        {
            return (T)array.GetValue(indices);
        }
    }
