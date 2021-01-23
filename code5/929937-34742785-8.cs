    public abstract class VehicleControllerBase : ApiController {
        [Route("move")] //All inheriting classes will now have a `{controller}/move` route 
        public virtual HttpResponseMessage Move() {
            ...
        }
    }
    [RoutePrefix("car")] // will have a `car/move` route
    public class CarController : VehicleControllerBase { 
        public virtual HttpResponseMessage CarSpecificAction() {
            ...
        }
    }
    [RoutePrefix("bike")] // will have a `bike/move` route
    public class BikeController : VehicleControllerBase { 
        public virtual HttpResponseMessage BikeSpecificAction() {
            ...
        }
    }
    [RoutePrefix("bus")] // will have a `bus/move` route
    public class BusController : VehicleControllerBase { 
        public virtual HttpResponseMessage BusSpecificAction() {
            ...
        }
    }
