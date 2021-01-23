    public class VehicleChasingState : State<Vehicle>
    {
        public VehicleChasingState(Vehicle unit)
            : base(unit)
        {
        }
        
        public override void Handle()
        {
            //  Here you can implement the "chasing" logic for a Vehicle.
            this.Unit.X = ????;
            this.Unit.Y = ????;
            
            if(this.Unit.HasRadar)
            {
                //  Do special "chasing" logic when the vehicle has radar.
            }
        }
    }
