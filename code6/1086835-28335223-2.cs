    public class DVDDHW : IPowerSupply
    {
        static readonly IPowerSupply _instance = DVDDHW();
        public static IPowerSupply Instance
        {
            get { return _instance; }
        }
        private DVDDHW() { }
        public bool setSupply(double voltage)
        {
            i2c.write("DVDD ON"); //or something that involves turning the real hardware on
            return true;
        }
    }
