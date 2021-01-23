    var topTwo = People.Where(a => a.Age > 18).Take(2).ToArray();
    Person p1, p2;
    if (topTwo.Any())
    {
       p1 = topTwo[0];
       if (topTwo.Count > 1)
           p2 = topTwo[1];
    }
