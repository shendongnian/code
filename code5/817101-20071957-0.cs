        class SpaceObject
        {
            public virtual void draw()
            {
                Console.WriteLine("Log from parent");
            }
        }
        class Sun : SpaceObject
        {
            public override void draw()
            {
                Console.WriteLine("Log from Child");
            }
        }
