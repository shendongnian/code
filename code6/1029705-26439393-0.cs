    public class Lib
    {
        private static string _commonVarialble;
        public static string CommonVarialble
        {
            get { return _commonVarialble; }
            set { _commonVarialble = value; }
        }
        public class SteelBeamShape
        {
            // constructor
            public SteelBeamShape(string steelBeamNominalValue)
            {
                // look up some properties base on nominal value in XML tables
                this.xmlDataPath = CommonVarialble;
                // do stuff .... 
            }
        }
    }
