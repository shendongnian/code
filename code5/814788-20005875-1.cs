    public PatientCardObject GetPatientCardDataWithVisits(int personId)
    {
        return GetPatientCardDataWithVisitsHelper(personId).First();
    }
    public PatientCardObject GetPatientCardData(int personId)
    {
        return GetPatientCardDataWithVisitsHelper(personId)
            .Select(person => new PatientCardObject
            {
                Person = person.Person
            }).First();
    }
