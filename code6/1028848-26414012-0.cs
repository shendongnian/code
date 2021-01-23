    using System;
    public class basic_data_structure
    {
        public static void Main()
        {
            int[] int_array = new int[] { 1, 2, 3, 4, 5 }; // type = System.Int32[]
            float[] float_array = new float[] { 1F, 2F, 3F, 4F, 5F }; // type = System.Single[]
            string[] string_array = new string[] { "a", "b", "c", "d", "e" }; // type = System.String[]
            print_any_array01(int_array);
            print_any_array01(float_array);
            print_any_array01(string_array);
            Console.ReadKey();
        }
        public static void print_any_array01(Array any_array)
        {
            int count = 0;
            int[] int_array = any_array as int[];
            float[] float_array = any_array as float[];
            string[] string_array = any_array as string[];
            if (int_array != null)
            {
                foreach (int element in int_array)
                {
                    count += 1;
                    Console.WriteLine("Element #{0}: {1}", count, element);
                }
            }
            else if (float_array  != null)
            {
                foreach (float element in any_array)
                {
                    count += 1;
                    Console.WriteLine("Element #{0}: {1}", count, element);
                }
            }
            else if (string_array != null)
            {
                foreach (string element in any_array)
                {
                    count += 1;
                    Console.WriteLine("Element #{0}: {1}", count, element);
                }
            }
            else
            {
                Console.WriteLine("ERROR unknown data type array!!!");
            }
        }
    }
