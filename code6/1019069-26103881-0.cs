    public int empAge
    {
        get
        {
            DateTime birthdate = DateTime.Parse(empDOB);
            int age = DateTime.Now.Year - birthdate.Year;
            if (DateTime.Now.DayOfYear < birthdate.DayOfYear)
            {
                age = age - 1;
            }
            return age;
        }
    }
