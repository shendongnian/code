    private IQueryable<PatientCardObject> GetPatientCardDataWithVisitsHelper(int personId)
    {
        return _people.AsNoTracking()
            .Where(person => person.Id == personId)
            .Select(person => new PatientCardObject
            {
                Person = new Person // COMMON PART
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Addresses = person.Addresses
                        .Where(address => address.IsCurrent && address.AddressTypeId == AddressType)
                        .Select(address => new Address
                        {
                            City = address.City,
                            Street = address.Street,
                            StreetNo = address.StreetNo,
                            ZipCode = address.ZipCode
                        }),
                },
                Visits = person.PatientVisits.Select(visit => new Visit
                {
                    Description = visit.Description,
                    StartTime = visit.StartTime,
                    EndTime = visit.EndTime,
                })
            });
    }
