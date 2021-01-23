    public IEnumerable<DriverDto> GetRealDrivers()
    {
        using (var ctx = new F1Entities())
        {
            var result = from d in ctx.Drivers
                         select new DriverDto 
                         {
                             Name = d.Name,
                             Cost = d.Cost,
                             Team = d.Team
                         };
            return result.ToList();
        }
    }
