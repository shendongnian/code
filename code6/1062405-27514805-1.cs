    public List<Car> GetAllCars()
    {
        using (CarContext context = new CarContext())
        {
            var returnList = new List<Car>();
            foreach(var car in context.Cars)
            {
                car.Brand = context.Metadata
                                   .Where(x => x.Key == car.BrandId && x.Type == "Brand")
                                   .FirstOrDefault();
                car.Model = context.Metadata
                                   .Where(x => x.Key == car.ModelId && x.Type == "Model")
                                   .FirstOrDefault();
                car.Color = context.Metadata
                                   .Where(x => x.Key == car.ColorId && x.Type == "Color")
                                   .FirstOrDefault();
                returnList.Add(car);
            }
            return returnList;
        }
    }
