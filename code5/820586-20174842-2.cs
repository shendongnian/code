    public class Controller
    {
        public void ViewCarDetails(int id)
        {
            var carService = new BLL.CarService();
            var car = carService.FindCarById(id);
            // populate UI with `car` properties
        }
    }
