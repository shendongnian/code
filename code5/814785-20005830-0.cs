    public PatientCardObject GetPatientCardDataWithVisits(int personId)
    {
        var filteredPeople = _people.AsNoTracking()
            .Include(person => person.Address)
            .Include(person => person.PatientVisits)
            .First(person => person.Id == personId);
    
        return new PatientCardObject { Person = CreatePersonFromModel(person) };
    }
