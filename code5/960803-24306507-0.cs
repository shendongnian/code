    SortedList<string, object> testIds = OrigOrderedList.Reverse() // should do the work
    static void Main(string[] args)
        {
          SortedList<string, object> test1 = new SortedList<string, object>();
          test1.Add("a", "A");
          test1.Add("b", "B");
          test1.Add("c", "C");
          Console.WriteLine(String.Join(", ", test1.Select(x => x.Key)));
          Console.WriteLine(String.Join(", ", test1.Reverse().Select(x => x.Key)));
        }
