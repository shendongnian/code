    var people = new List<Person>
    {
         new Person {FullName = "Some Dude", Age = 45},
         new Person {FullName = "Another Dude", Age = 28},
         new Person {FullName = "Some Other Dude", Age = 36}
    };
    var filtered = people.Where(person => person.Age > 28 && person.FullName.StartsWith("So"));
    var narrowlyFiltered = people.Where(person => person.Age > 36 && person.FullName.StartsWith("Some"));
    var intersection = filtered.Intersect(narrowlyFiltered);
    if (intersection != null)
    {
        if (intersection.Count() > 0)
        {
            //narrowlyFiltered is subset of filtered
        }
    }
