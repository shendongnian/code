    public class Animal
    {
        public Animal(float speed)
        {
            this.Speed = speed;
        }
    
        public float Speed { get; set; }
    }
    
    public abstract class Feline : Animal
    {
        protected Feline(float speed, float sightRange) : base(speed)
        {
            this.SightRange = sightRange;
        }
    
        public float SightRange { get; set; }
    }
    
    public class Lion : Feline
    {
        public Lion(float speed, float sightRange, float strength) : base(speed, sightRange)
        {
            this.Strength = strength;
        }
    
        public float Strength { get; set; }
    }
