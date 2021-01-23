    public IEnumerable<Person> SearchByAgeRange(int AgeMin, int AgeMax)
    {
        DateTime minDate = DateTimeNow.AddYears(-AgeMax);
        DateTime maxDate = DateTimeNow.AddYears(-AgeMin);
    
        return Persons.Where(x=>x.Birthdate>=minDate && x.BirthDate<=maxDate);
    }
    
