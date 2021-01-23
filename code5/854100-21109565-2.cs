    public static void SwapFirstAndLastNames(this IEnumerable<INamedEntity> persons)
    {
        foreach (var person in persons)
        {
            string oldLastName = person.LastName;
            person.LastName = person.FirstName;
            person.FirstName = oldLastName;
        }
    }
