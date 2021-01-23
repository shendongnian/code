        static void Main(string[] args)
        {
            int[] arr = new int[3];           
            string[] st = { "I like apples.", "I like red apples.", 
                                 "I like red apples than green apples." };
            int counter = 0;
            foreach (string s in st)
            {
                int NumberOfWords = s.Split(' ').Length;
                arr[counter] = NumberOfWords;
                counter++;
            }
            Array.Sort(arr);
            Console.WriteLine(st[arr.Length - 1]);
        }
