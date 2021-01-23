    public interface IPowerSupply
    {
        bool setSupply(double voltage);
    }
    
    public class DVDDHW : IPowerSupply
    {
        IPowerSupply _instance;
        public static IPowerSupply Instance
        {
            get
                {
                    if (_instance == null)
                        _instance = new DVDDHW();
                    return _instance;
                }
        }
        private DVDDHW() { }
        public bool setSupply(double voltage)
        {
            i2c.write("DVDD ON"); //or something that involves turning the real hardware on
            return true;
        }
    }
    
    public class DVDD : IPowerSupply
    {
        public bool setSupply(double voltage)
        {
            DevLog.DevLog.addToLog(string.Format("Supply set: {0}V: ", voltage) + this.GetType().ToString());
            if (G.demoMode == false) //demoMode is false because HW is connected
                {
                    DVDDHW.setSupply(voltage); //What is another way to accomplish this?
                }
            return true;
        }
    }
    
    
    //Code to execute below:
    foreach PowerSupply ps in PowerSupplyList // List contains an instance of DVDD in this example
    {
        ps.setSupply(3.5); // Set each supply to 3.5V
    }
