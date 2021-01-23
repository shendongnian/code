    public IEnumerable<Person> GetList1(IEnumerable<Person> source, int rating) {
        return source.Where(person => person.Rating1 == rating
            || person.Rating2 == rating)
            .GroupBy(person => new int[] { person.Rating1, person.Rating2 }
                .OrderBy(r => r), new SequenceComparer<int>())
            .Select(group => group.OrderByDescending(p => p.CreateDate)
                .First());
    }
