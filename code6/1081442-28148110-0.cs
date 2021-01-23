        static void Main()
        {
            using(var iter = GetData().GetEnumerator())
            {
                System.Console.WriteLine("Have iterator");
                while(iter.MoveNext())
                {
                    System.Console.WriteLine(iter.Current);
                }
                System.Console.WriteLine("Done");
            }
        }
        static IEnumerable<int> GetData()
        {
            System.Console.WriteLine("Before doing anything");
            yield return 1;
            yield return 2;
            yield return 3;
            System.Console.WriteLine("Ater doing everything ");
        }
