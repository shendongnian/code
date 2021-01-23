    using System.Linq;
    ...
    var rnd = new Random();
    var m = Enumerable.Range(0, 10000).Select(i => rnd.Next(10000));
    var result = m.OrderBy(i => i).Take(n);
