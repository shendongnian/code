    var depos = new Autokereskedes.Models.SampleData.Depos().List();
    depos.ForEach(d => context.Depos.Add(d));
    context.SaveChanges();
    var cars = new Autokereskedes.Models.SampleData.Cars().List(depos);
    public List<Car> List(IEnumerable<Depo> depos)
    {
        // now you have depos to look for id's in
        return new List<Car>
        {
            new Car {
                CarId = Guid.NewGuid(),
                DepoId = depos.SingleOrDefault(x => [your predicate]),
            },
            new Car {
            }
        };
    }
