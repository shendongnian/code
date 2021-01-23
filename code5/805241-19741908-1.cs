        interface ICar
        {
            int Speed { get; set; }
            void Accelerate();
        }
        class Car : ICar
        {
            public int Speed { get; set; }
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
            public int Speed { get; set; }
            public void Accelerate()
            {
                modified.Accelerate();
                modified.Speed += 1;
            }
        }
        ICar car = new Radial(new Car());
        car.Accelerate();
