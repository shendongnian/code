    var join = from p1 in initialList.Select((p, i) => new { Person = p, Index = i })
               join p2 in secondList on p1.Person.Value equals p2.Value
               select new { Index = p1.Index, Replacement = p2 };
    foreach (var item in join.ToList())
    {
        initialList[item.Index] = item.Replacement;
    }
