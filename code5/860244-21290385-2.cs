    public class Device
    {
        public Device(string status)
        {
            this._status = status;
        }
        protected _status;
        public virtual string Status 
        { 
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
    }
    public class Light : Device
    {
        public Light(string status) : base(status)
        {
        }
    }
    public class ColoredLight : Light
    {
        public ColoredLight(string status) : base(status)
        {
        }
        public override string Status 
        { 
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
    }
