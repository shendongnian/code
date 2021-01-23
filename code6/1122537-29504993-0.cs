    // Base Abstract Class
    public abstract class Avenger
    {
        public virtual string MyVehicle
        {
            get
            {
                if (MyVehicle == null)  // Default the value if it is null
                    MyVehicle = "Quinjet";  
                return MyVehicle;
            }
            set; // Allow the child class to set their own vehicle
        }
    }
    // Derrived class piggy-backs off of the parent's implementation
    public class Hulk : Avenger
    {}
