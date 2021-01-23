    public interface ICar
    {
        void Update(ICar car);
    }
    
    public class Peugeot : ICar
    {
        public void Update(Peugeot car)
        {
            Update(car);
        }
    
        void ICar.Update(ICar car)
        {
            // do some updating
        }
    }
    
    public class Volvo : ICar
    {
        public void Update(Volvo car)
        {
            Update(car);
        }
    
        void ICar.Update(ICar car)
        {
            // do some updating
        }
    }
