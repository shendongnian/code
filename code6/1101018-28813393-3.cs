    public void AddOrUpdate(Car car)
    {
        if (car.Id == default(int)) {
            // New entity
            context.Cars.Add(car);
        } else {
            // Existing entity
            context.Entry(car).State = EntityState.Modified;
        }
    }
  
