        public List<Car> Get()
        {            
            var cars = _context.Cars
                .Include(car => car.Coordinates)
                .Include(car => car.Client)
                .ToList();
            return cars;
        }
