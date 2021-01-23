    class Program
        {
            static void Main(string[] args)
            {
                int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                var b = GetRange(a.AsEnumerable(), 2, 2);
                foreach (var i in b)
                {
                    Console.WriteLine(i);
                }
                Console.ReadLine();
            }
    
            private static List<int> GetRange(IEnumerable<int> intList, int current, int range)
            {
                List<int> lst = new List<int>();
                int newCurrent = current;
                for (int i = 0; i < range; i++)
                {
                    newCurrent = GetNext(intList, newCurrent);
                    lst.Insert(0, newCurrent);
                    lst.Reverse();
                }
    
                newCurrent = current;
                for (int i = 0; i < range; i++)
                {
                    newCurrent = GetPrevious(intList, newCurrent);
                    lst.Insert(0, newCurrent);
                }
    
                return lst;
            }
    
            private static int GetNext(IEnumerable<int> intList, int current)
            {
                return intList.SkipWhile(i => !i.Equals(current)).Skip(1).First();
            }
    
            private static int GetPrevious(IEnumerable<int> intList, int current)
            {
                return intList.TakeWhile(i => !i.Equals(current)).Last();
            }
    
    
        }
