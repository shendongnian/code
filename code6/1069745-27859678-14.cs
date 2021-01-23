    public class FuelEventArgs : EventArgs
    {
        private float oldFuel, newFuel;
        public FuelEventArgs(float oldFuel, float newFuel)
        {
            this.oldFuel = oldFuel;
            this.newFuel = newFuel;
        }
    }
    public class FuelEvents
    {      
        public event EventHandler FireEventHandler;
        public virtual void FireEvent(object sender, EventArgs fuelArgs)
        {
            EventHandler handler = FireEventHandler;
            if (null != handler)
                handler(this, fuelArgs);
        }
    }
    public class FuelChanged : FuelEvents
    {             
        public override void FireEvent(object sender, EventArgs fuelArgs)
        {
            Console.WriteLine("Fired FuelChanged");
            base.FireEvent(sender, fuelArgs);
        }
    }
    public class FuelEmpty : FuelEvents
    {
        public override void FireEvent(object sender, EventArgs fuelArgs)
        {
            Console.WriteLine("Fired FuelEmpty");
            base.FireEvent(sender, fuelArgs);
        }
    }
    public class FuelFull : FuelEvents
    {
        public override void FireEvent(object sender, EventArgs fuelArgs)
        {
            Console.WriteLine("Fired FuelFull");
            base.FireEvent(sender, fuelArgs);
        }
    }
    public class FuelNoLongerEmpty : FuelEvents
    {
        public override void FireEvent(object sender, EventArgs fuelArgs)
        {
            Console.WriteLine("Fired FuelNoLongerEmpty");
            base.FireEvent(sender, fuelArgs);
        }
    }
    public class FuelNoLongerFull : FuelEvents
    {
        public override void FireEvent(object sender, EventArgs fuelArgs)
        {
            Console.WriteLine("Fired FuelNoLongerFull");
            base.FireEvent(sender, fuelArgs);
        }
    }
