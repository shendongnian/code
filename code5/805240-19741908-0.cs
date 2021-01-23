<pre> interface ICar
  {
     int Speed { get; set; }
     void Accelerate();
  }
  class Car : ICar
  {
       private int speed = 0;
       public int Speed
       {
           get { return speed; }
           set { speed = value; }
       }
       public virtual void Accelerate()
       {
           Speed += 5;
       }
    }
    class Radial : ICar
    {
        private readonly ICar modified;
        Radial(ICar modified)
        {
            this.modified = modified;
        }
        public void Accelerate()
        {
            modified.Accelerate();
            modified.Speed += 1;
        }
    }
ICar car=new Radial(new Car());
</pre>
