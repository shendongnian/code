    public class CarService : ICarService
    {
        public List<Car>  CareDetail()  
        {
            using (CarDataContext db = new CarDataContext())
            {
                return db.Cars.ToList();
    }}}
