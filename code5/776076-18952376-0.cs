        public class BikeController : Controller
        {
            //
            // GET: /Bike/
        
            List<Bike> bikes;
        
            public BikeController()
            {
               bikes = new List<Bike>() {
                   new Bike(),
                   new Bike { Manufacturer = "Nishiki", Gears = 5, Frame = "Road" }
               };
            }
        
            ...
       }
