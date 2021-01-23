    public class Markets
    {
        public COLXPM this[string key]
        {
            get
            {
                COLXPM colxpm;
                switch (key)
                {
                    // TODO : use "key" to select instance of COLXPM;
                    case "example1":
                        colxpm = ...;
                        break;
                    default:
                        throw new NotSupportedException();
                }
                return colxpm;
            }
        }
    }
