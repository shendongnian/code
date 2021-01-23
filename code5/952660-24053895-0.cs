    public class Car
    {
        BreakModule _breakModule;
        Chassis _chassis;
        Wheel _wheel;
        Seat _seat;
        Headlight _headlight;
        public Car(BreakModule breakModule, Chassis chassis, Wheel wheel, Seat seat, Headlight headlight)
        {
            this._breakModule = breakModule;
            this._chassis = chassis;
            this._wheel = wheel;
            this._seat = seat;
            this._headlight = headlight;
        }
        private Car()
        {
        }
    }
