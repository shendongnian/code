    using System.Linq;
    
    IList<Foo> list = new List<Foo>();
    IEnumerable<Foo> sortedEnum = list.OrderBy(f=>f.Bar);
    IList<Foo> sortedList = sortedEnum.ToList();
