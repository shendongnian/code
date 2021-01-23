    public IEnumerable<Doctor> SearchDoctors(string field, string rangeStart)
    {
        return Search(doctorList, field, rangeStart);
    }
    
    public IEnumerable<Doctor> SearchDoctors(string field, string rangeStart, string rangeEnd)
    {
        return Search(doctorList, field, rangeStart, rangeEnd);
    }
    
    public IEnumerable<Patient> SearchPatients(string field, string rangeStart)
    {
        return Search(patientList, field, rangeStart);
    }
    
    public IEnumerable<Patient> SearchPatients(string field, string rangeStart, string rangeEnd)
    {
        return Search(patientList, field, rangeStart, rangeEnd);
    }
    
    public IEnumerable<Visit> SearchVisits(string field, string rangeStart)
    {
        return Search(visitList, field, rangeStart);
    }
    
    public IEnumerable<Visit> SearchVisits(string field, string rangeStart, string rangeEnd)
    {
        return Search(visitList, field, rangeStart, rangeEnd);
    }
    
    public IEnumerable<Treatment> SearchTreatments(string field, string rangeStart)
    {
        return Search(treatmentList, field, rangeStart);
    }
    
    public IEnumerable<Treatment> SearchTreatments(string field, string rangeStart, string rangeEnd)
    {
        return Search(treatmentList, field, rangeStart, rangeEnd);
    }
    private IEnumerable<T> Search<T>(IEnumerable<T> list, string field, string rangeStart, string rangeEnd = null)
    {
        // more code that isn't relevant to the question here
    }
