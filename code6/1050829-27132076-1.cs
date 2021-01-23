    public abstract class Vehicle
    {
        private string name;
    
        public string getName()
        {
            return name;
        }
    
        public string setName(string name)
        {
            this.name = name; 
        }
    }
    
    public class Car : Vehicle
    {
        public Car()
        {
            setName("Car");
        }
    }
