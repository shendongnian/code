    protected override void Seed(AutoDb context)
    {
        new Autokereskedes.Models.SampleData.Users().List()
            .ForEach(u=>context.Users.Add(u));
        var cars = new Autokereskedes.Models.SampleData.Cars().List();
        var depos = new Autokereskedes.Models.SampleData.Depos().List();
        foreach (var car in cars)
        {
            car.DepoId = depos.FirstOrDefault(x => x.DepoId == ...?);
            context.Cars.Add(car);
        }
    }
