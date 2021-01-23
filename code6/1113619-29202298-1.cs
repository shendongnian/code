    public class CarRepository
    {
        public List<Car> FindAll()
        {
            // Code to retrieve all cars 
        }
    
        public List<Car> FindAllWith(string carModel)
        {
            // Code to retrieve all cars with a particular model
        }
    
        public List<Car> FindAllWith(int parkingGarageId)
        {
            // Code to retrieve all cars from a particular parking garage
        }
        public void Save(Car car)
        {
           // Code to save car to the database
        }
    }
