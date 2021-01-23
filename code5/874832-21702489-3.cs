    private string _patientNumber;
    public string PatientNumber
    {
        get
        {
            if (string.IsNullOrWhiteSpace(_patientNumber))
            {
                try
                {
                    var cp = ClaimsPrincipal.Current.Identities.First();
                    var patientNumber = cp.Claims.First(c => c.Type == "PatientNumber").Value;
                    _patientNumber = patientNumber;
                }
                catch (Exception)
                {
                }
            }
            return _patientNumber;
        }
    }
