    public static IEnumerable<Person> DescendantsAndSelf(this Person person)
    {
        yield return person;
        foreach (var item in person.Children.SelectMany(x => x.DescendantsAndSelf()))
        {
            yield return item;
        }
    }
