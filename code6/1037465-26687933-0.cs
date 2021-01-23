            var list = new List<int> { 0, 4, 1, 3 };
            list.Sort();
            for (int i = 0; i < list.Count; i++)
            {
                if (!list.Contains(i))
                {
                    Console.WriteLine("Missing {0}", i);
                    break;
                }
            }
