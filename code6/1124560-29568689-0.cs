    public class CarModelBuilder()
    {
        // prevent from creating this directly
        private CarModelBuilder()
        {
        }
    
        public static CarModelBuilder Build()
        {
             return new CarModelBuilder();
        }
    
        public CarModelBuilder Wheel(Wheel wheel)
        {
             // add wheel here
             return this;
        }
    
        public CarModelBuilder Door(Door door)
        {
             // add door here
             return this;
        }
    
        public CarModelBuilder Engine(Engine engine)
        {
             // add engine here
             return this;
        }
    
        // etc
        // completion
        public Car Complete() 
        {
             // complete modelling here
             return new Car();
        }
    }
