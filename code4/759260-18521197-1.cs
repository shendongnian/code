    public class Repository : IRepository
    {
        private int CarId;
        public void GetCarId(Action<int> callback)
        {
            callback(CarId);
        }
        public void setDictionary(int carId)
        {
            CarId = carId;
        }
    }
