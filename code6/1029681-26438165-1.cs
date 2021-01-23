        private static void Main(string[] args)
        {
             var ints = new[] { 4, 5, 3, 1, 6 };
             foreach (var item in ints.Select((x, i)=>new { OldIndex = i, Value = x, NewIndex = -1})
                                      .OrderByDescending(x=>x.Value)
                                      .Select((x, i) => new { OldIndex = x.OldIndex, Value = x.Value, NewIndex = i + 1})
                                      .OrderBy(x=>x.OldIndex))
                 Console.Write(item.NewIndex + " ");
    
        }
