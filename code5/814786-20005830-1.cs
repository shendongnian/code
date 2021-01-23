    public IEnumerable<PatientCardObject> GetPatientCardDataWithVisits(int personId)
    {
        var filteredPeople = _people.AsNoTracking()
            .Include(person => person.Address)
            .Include(person => person.PatientVisits)
            .Where(person => person.Id == personId)
            .Take(100)
            .AsEnumerable()
           .Select(x => new PatientCardObject { Person = CreatePersonFromModel(x) });
    
        return filteredPeople;
    }
