    using System.Linq;
    ...
    var list1 = new List<string> { "A", "B", "C" };
    var list2 = new List<string> { "1", "2", "3" };
    var list3 = list1.Zip(list2, (x, y) => x + y).ToList(); // { "A1", "B2", "C3" }
