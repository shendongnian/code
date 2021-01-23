            string first = Console.ReadLine();
            int len = first.Split(new []
                             {' '},StringSplitOptions.RemoveEmptyEntries).Length;
            string[] First = new string[len];
            for (int i = 0; i < len; i++)
            {
                First[i] = first.Split(' ')[i];
            }
            int[] Arr = new int[First.Length];//int array for string console values
            for (int i = 0; i < First.Length; i++)//goes true all elements and converts them into Int32
            {
                Arr[i] = Convert.ToInt32(First[i].ToString());
            }
            for (int i = 0; i < Arr.Length; i++)//print array to see what happened
            {
                Console.WriteLine(Arr[i]);
            }
