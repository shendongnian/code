            return
                (from car
                     in this.Context.Cars
                        where car.Purchase != null
                        group car by car.Engine into g
                   select new { EngineName = g.Key.Name, CountSold = g.Count()})
                .OrderByDescending(x => x.CountSold)
                .ToList();
