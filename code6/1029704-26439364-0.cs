    public abstract class BaseShape
    {
        public static string mSomeVar = "SomeValue";
    }
    public class SteelBeamShape : BaseShape
    {
        // constructor
        public SteelBeamShape(string SteelBeamNominalValue)
        {
            // look up some properties base on nominal value in XML tables
            this.xmlDataPath = this.mSomeVar;
    
            // do stuff .... 
        }
    }
    public class SteelPipeShape : BaseShape
    {
        // constructor
        public SteelPipeShape(string SteelPipeNominalValue)
        {
            // look up some properties base on nominal value in XML tables
            this.xmlDataPath = this.mSomeVar;
    
            // do stuff .... 
        }    
    }
