    public static class ReverseHelper
    {
        public static void MyReverse<T>(IList<T> source)
        {
            var length = source.Count;
            var hLength = length / 2;
            for (var i = 0; i < hLength; i++)
            {
                T temp = source[i];
                source[i] = source[length - 1 - i];
                source[length - 1 - i] = temp;
            }
        }
    }
