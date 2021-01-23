    using System.Linq;
    ...
    List<int> list = new List<int>();
    list.AddRange(new []{1,2,3,4,5,6});
    int count = list.Count(n => n > 2); // 4
