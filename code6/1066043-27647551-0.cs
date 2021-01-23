    static void Main(string[] args)
        {
            Tree t = new Tree();
 
            int n = 6;
            int[] strs = new int[n];
            for (int i = 0; i < n; i++)
            {
                strs[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                t.Add(strs[i]);
           }
 
            t.Print();
 
        }
