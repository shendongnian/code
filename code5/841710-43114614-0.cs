        public static void Main(string[] args)
        {
            //Array list to store all the duplicate values
            int[] ary = { 10, 5, 10, 2, 2, 3, 4, 5, 5, 6, 7, 8, 9, 11, 12, 12 };
            ArrayList dup = new ArrayList();
            for (int i = 0; i < ary.Length; i++)
            {
                for (int j = i + 1; j < ary.Length; j++)
                {
                    if (ary[i].Equals(ary[j]))
                    {
                        if (!dup.Contains(ary[i]))
                        {
                            dup.Add(ary[i]);
                        }
                    }
                }
            }
            Console.WriteLine("The numbers which duplicates are");
            DisplayArray(dup);
        }
        public static void DisplayArray(ArrayList ary)
        {
            //loop through all the elements
            for (int i = 0; i < ary.Count; i++)
            {
                Console.Write(ary[i] + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
