    public int Insert(List<Car> Cars)
    {            
        int addedCars = 0;
        foreach (Car t in Cars)
        {
            _db.Cars.Add(t);
            try
            {
                _db.SaveChanges();
                addedCars++;
            }
            catch (DbUpdateException ex)
            {
                _db.cars.Remove(t); // Remove it from the context collection
                Console.WriteLine("Whups duplicate entry");
            }
        }
        return addedCars;
    }  
