    public static IEnumerable<Person> GetPeople(string filepath)
    {
        foreach (var line in File.ReadLines(filepath))
        {
            var properties = line.Split(',');
            yield return new Person(properties[0], int.Parse(properties[1]), etc...
            //according to properties of Person class
        }
    }
    //you can call it like
    var people = GetPeople("Data.txt").ToList();
    //your foreach calls will look almost the same:
    foreach (var district in people.Select(x => x.Place).Distinct().OrderBy(x => x))
        Console.WriteLine("District {0} has {1} resident(s)", district, people.Count(x => x.Place == district));
    Console.WriteLine("Ages 0-18 : {0} resident(s)", people.Count(x => x.Age < 18));
    Console.WriteLine("Ages 18-30 : {0} resident(s)", people.Count(x => x.Age >= 18 && x.Age <= 30));
    Console.WriteLine("Ages 31-45 : {0} resident(s)", people.Count(x => x.Age >= 31 && x.Age <= 45));
    Console.WriteLine("Ages 46-64 : {0} resident(s)", people.Count(x => x.Age >= 46 && x.Age <= 64));
    Console.WriteLine("Ages >=65 : {0} resident(s)", people.Count(x => x.Age >= 65));
