    using System;
    namespace test
    {
        class Program
        {
            // *** Examples of what you can do with BoundedArray ***
            // Multi-dimensional, bounded base array
            class BaseArray : BoundedArray<int>
            {
                public BaseArray()
                {
                    SetAttributes(IntArray.FromValues(2, 3), IntArray.FromValues(2, 4));
                }
            }
            // One-dimensional, bounded subclass array
            class SubArray : BoundedArray<BaseArray>
            {
                public SubArray()
                {
                    SetAttributes(IntArray.FromValues(4, 6));
                }
            }
            static void Main(string[] args)
            {
                // Initializations used for testing purposes
                BaseArray baseArray = new BaseArray();
                SubArray subArray = new SubArray();
                // Example of assignment
                baseArray[3, 4] = 3;
                subArray[4][2, 3] = 4;
                subArray[4][2] = 3; // Weakness: compiles, but causes IndexOutOfRangeException
                Console.Read();
            }
        }
    }
