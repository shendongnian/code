        public List<Car> Get()
        {
            // get all cars
            var cars = _context.Cars.ToList();
            // get all coordinates: the context will populate the Coordinates 
            // property on the cars loaded above
            var coordinates = _context.Coordinates.ToList();
            return cars;
        }
