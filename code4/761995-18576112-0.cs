    private IQueryable<Car> getCommonQuery()
    {
                DataContext.AsQueryableFor<RTraining>()
                .Include(rb => rb.Car.CarStatus)
                .Include(rb => rb.Car.Item.Customer)
                .Include(rb => rb.Car.Item.MyItem.Wheel.Customer);
    }
    
    public Car GetCarByChildEntityId(long id)
    {
         return executeQuery(getCommonQuery()).SingleOrDefault(rb => rb.Id == id).Car;
    }
    
    public IEnumerable<IEntity> GetEntities()
    {
         return executeQuery(getCommonQuery()).OfType<IEntity>();
    }
