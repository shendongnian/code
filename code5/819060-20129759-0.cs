    using System;
    
    class Program
    {
        /// <summary>
        /// Used in Shuffle(T).
        /// </summary>
        static Random _random = new Random();
    
        /// <summary>
        /// Shuffle the array.
        /// </summary>
        /// <typeparam name="T">Array element type.</typeparam>
        /// <param name="array">Array to shuffle.</param>
        public static void Shuffle<T>(T[] array)
        {
    	var random = _random;
    	for (int i = array.Length; i > 1; i--)
    	{
    	    // Pick random element to swap.
    	    int j = random.Next(i); // 0 <= j <= i-1
    	    // Swap.
    	    T tmp = array[j];
    	    array[j] = array[i - 1];
    	    array[i - 1] = tmp;
    	}
        }
