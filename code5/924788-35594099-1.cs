    var Policy = "123";
    var Results=   db
            .MultipleResults($"EXEC Diamond.GetPolicyInfo '{Policy}'")
            .AddResult<Driver>()
            .AddResult<Address>()
            .AddResult<Phone>()
            .AddResult<Email>()
            .AddResult<Vehicle>()
            .Execute();
            var Output= new clsPolicyInfo
            {
                Drivers = Results[0] as Driver[],
                Addresses = Results[1] as Address[],
                Phones = Results[2] as Phone[],
                Emails = Results[3] as Email[],
                Vehicles = Results[4] as Vehicle[]
            };
