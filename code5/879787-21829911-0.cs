    public class Test
    {
        private string _testProperty;
        private bool testPropertyIsSet = false;
        public string TestProperty
        {
            get { return this._testProperty; }
            set 
            {  
                _testProperty = value;
                if (!testPropertyIsSet)
                {
                     // Do something here when your property gets set for the first time
                }
                testPropertyIsSet  = true;
            }
        }
    }
