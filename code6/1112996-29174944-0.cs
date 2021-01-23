     List<int> Attacks  = new List<int>();
            Attacks.Add(1);
            Attacks.Add(2);
            Attacks.Add(3);
            Attacks.Add(4);
            Attacks.Add(5);
            Attacks.Add(6);
            int SumOfInts = 0;
            foreach (int i in Attacks)
                SumOfInts += i;
            Console.WriteLine("Sum of Attacks {0}", SumOfInts);
            Console.Read();
