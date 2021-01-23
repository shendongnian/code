    public class Car
    {
        public readonly string Name;
    
        public string color {get; private set;}
    
        public Car()
        {
            Name = "Car";
            Color = "Red";
        }
    
        // will fail compilation
        public void ModifyName()
        {
            Name = "Subaru"
        }
    
        // perfectly ok
        public void ModifyColor()
        {
            Color = "Green"
        }
    }
