    public IEnumerable<Person> SearchByAgeRange(int AgeMin, int AgeMax)
    {
        // If the maximum age you are looking for is for instance 80, then you should
        // look for dates that are greater or equal of the current datetime minus 80 years.
        // This forms the minDate.
        DateTime minDate = DateTimeNow.AddYears(-AgeMax);
        
        // If the minimum age you are looking for is for instace 40, then you should 
        // look for dates that are less or equal of the current date minus 40 years.
        // This forms the maxDate.
        DateTime maxDate = DateTimeNow.AddYears(-AgeMin);
    
        return Persons.Where(x=>x.Birthdate>=minDate && x.BirthDate<=maxDate);
    }
    
