    public class FuelTank
    {
        private float fuel;
        //Basic classes for the event handling, could be done by providing a few simple delegates,
        //but this is just to stick as close to the original question as possible.
        public FuelChanged FuelChanged = new FuelChanged();
        public FuelEmpty FuelEmpty = new FuelEmpty();
        public FuelFull FuelFull = new FuelFull();
        public FuelNoLongerEmpty FuelNoLongerEmpty = new FuelNoLongerEmpty();
        public FuelNoLongerFull FuelNoLongerFull = new FuelNoLongerFull();
        public float MaxFuel { get; set; }
        public float Fuel
        {
            get
            {
                return fuel;
            }
            private set
            {
                var adjustedFuel = Math.Max(0, Math.Min(value, MaxFuel));
                if (fuel != adjustedFuel)
                {
                    var oldFuel = fuel;
                    fuel = adjustedFuel;
                    RaiseCheckFuelChangedEvents(oldFuel);
                }
            }
        }
        public void FillFuel()
        {
            Fuel = MaxFuel;
        }
        private void RaiseCheckFuelChangedEvents(float oldFuel)
        {
            FuelChanged.FireEvent(this, new FuelEventArgs(oldFuel, Fuel));
            if (fuel == 0)
            {
                FuelEmpty.FireEvent(this, EventArgs.Empty);
            }
            else if (fuel == MaxFuel)
            {
                FuelFull.FireEvent(this, EventArgs.Empty);
            }
            if (oldFuel == 0 && Fuel != 0)
            {
                FuelNoLongerEmpty.FireEvent(this, EventArgs.Empty);
            }
            else if (oldFuel == MaxFuel && Fuel != MaxFuel)
            {
                FuelNoLongerFull.FireEvent(this, EventArgs.Empty);
            }
        }      
    }
