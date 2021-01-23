    public IEnumerable<Person> SearchByAgeRange(this IEnumerable<Person> personCollection, int AgeMin, int AgeMax)
    {
        return personCollection.Where(c=> {
            var currentAge =(((DateTime.Now - c.Birthdate).TotalDays+1) / 365.25);
            return currentAge > AgeMin && currentAge<AgeMax;
        });
    }
