    class Program
        {
            public static int get_key(int key , int [,] keylist)
            {
                for (int i = 0; i <= keylist.GetUpperBound(0); ++i)
                {
                    if (keylist[i, 0] == key)
                        return keylist[i, 1];
                }
                return -1;
            }
           public static int[] Sort_by_index(int [] arr , int [] key , int [,] index_list)
            {
                int[] _out = new int[arr.Length];
    
                for (int i = 0; i < key.Length; i++)
                {
                    //Get key index
                    int key_index = get_key(key[i], index_list);
                    _out[i] = arr[key_index];
    
                }
                return _out;
            }
            static void Main(string[] args)
            {
                int[] a = { 120, 60, 50, 40, 30, 20 };
                int[] b = { 12, 29, 37, 85, 63, 11 };
                int[] c = { 30, 23, 90, 110, 21, 34 };
                int[,] a_index = { { 120, 0 }, { 60, 1 }, { 50, 2 }, { 40, 3 }, { 30, 4 }, { 20, 5 } };
                Array.Sort(a);
                b =Sort_by_index(b, a, a_index);
                c =Sort_by_index(c, a, a_index);
                Console.WriteLine("Result A");
                Console.WriteLine(string.Join(", ",a));
                Console.WriteLine("Result B");
                Console.WriteLine(string.Join(", ",b));
                Console.WriteLine("Result C");
                Console.WriteLine(string.Join(", ",c));
                Console.ReadKey(false);
                
            }
        }
