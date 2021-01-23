            List<string> MyStrings = new List<string>();
            Console.Write("Enter the number of strings you want to create > :: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                MyStrings.Add("String"+i.ToString());
            }
            foreach (var str in MyStrings)
            {
                Console.WriteLine(str);
            }
