    public class SomeClass
    {
        #region Properties
        public string Value { get; private set; }
        #endregion Properites
        #region Constructors
        public SomeClass()
        {
            Value = ConfigurationManager.AppSettings["DatValue"];
        }
        #endregion Constructors
    }
