            static void Main(string[] args)
            {
    
                string str1 = "fire";
                string str2 = "hire ";
                int count = 0;
                foreach (char obj in str1)
                    if (str2.Contains(obj.ToString()))
                    {
                        Console.WriteLine(obj);
                        count++;
                        //Console.ReadLine();
                    }
                Console.ReadLine();
    
            }
