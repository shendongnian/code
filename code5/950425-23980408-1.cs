    public class Car
    {
        // ... the other properties like in your class definition above
        
        public virtual Coordinates Coordinates { get; set;}
    }
    public void Get()
    {
        var cars = _context.Cars.ToList();
        var coordinates = cars.First().Coordinates; // EF loads the Coordinates of the first car NOW!
    }
