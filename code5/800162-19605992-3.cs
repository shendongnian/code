    var user = new User
    {
        UserID = Guid.NewGuid(), 
        Address = employmentAddress.Trim(), 
        ZipCode = int.Parse(zipcode.Trim()),
        UsersInHospitals = new List<UsersInHospital> //or array or whatever it is
        {
            new UsersInHospital
            {
                HospitalID = Guid.Parse(hospitalAff1),
                IsEmployed = Boolean.Parse(isEmployed1)
            },
            new UsersInHospital
            {
                HospitalID = Guid.Parse(hospitalAff2),
                IsEmployed = Boolean.Parse(isEmployed2)
            }
        }
    };
