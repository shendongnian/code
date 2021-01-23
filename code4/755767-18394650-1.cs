        static void Main(string[] args)
        {
            string s="";
            string s1 = "";
            Program obj = new Program();
            string[] arr1 = {"Cats and ratsasdfasdf", "just rats and the just catest", "rats"};
            s = arr1[0];
            s1 = arr1[0];
            
            /*Code for Find Shortest and longest string in Array*/
            for (int i = 0; i < arr1.Length; i++)
            {
                if (s.Length > arr1[i].Length)
                {
                    s = arr1[i];
                }
                if (s1.Length < arr1[i].Length)
                {
                    s1 = arr1[i];
                }
            }
           
            Console.WriteLine("shortest string is:"+s);
            Console.WriteLine("Longest string is:" + s1);
            Console.Read();
        }
