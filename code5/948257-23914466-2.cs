    public Age CalculatedAge
    {
        get
        {
            if (Patient.DateOfBirth == null && Patient.Age != null && Patient.Age.HasValue)
                return new Age(Patient.Age.Value);
            else if (Patient.DateOfBirth != null)
            {
                DateTime now = DateTime.UtcNow;
                TimeSpan tsAge = now - Patient.DateOfBirth;
                DateTime age = new DateTime(tsAge.Ticks);
                return new Age(age.Year - 1, age.Month - 1, age.Day - 1);
            }
            return new Age(0);
        }
    }
