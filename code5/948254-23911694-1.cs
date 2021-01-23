    public Age CalculatedAge
    {
        get
        {
            if (Patient.DateOfBirth.HasValue)
            {
                DateTime bday = Patient.DateOfBirth.Value;
                DateTime now = DateTime.UtcNow;
                if (bday.AddYears(1) < now)
                {
                    int years = now.Year - bday.year;
                    if (bday > now.AddYears(-years))
                        years--;
                    return new Age(years, AgeUnits.Years);
                }
                else if (bday.AddMonths(1) < now)
                {
                    int months = (now.Months - bday.Months + 12) % 12;
                    if (bday > now.AddMonths(-months))
                        months--;
                    return new Age(months, AgeUnits.Months);
                }
                else
                {
                    int days = (now - bday).Days;
                    return new Age(days, AgeUnits.Days);
                }
            }
            else
            {
                if (Patient.Age.HasValue)
                    return new Age(Patient.Age.Value, AgeUnits.Years);
                else
                    return null;
            }
        }
    }
