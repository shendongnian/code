    public class Foo
    {
        private double defaultEfficiency = 100.0;
        private double _efficiencyBar = defaultEfficiency;
       
        public double efficiencyBar
        {
            get
            {
                return _efficiencyBar;
            }
            set
            {
                _efficiencyBar = value;
                _efficiencyBarChanged = true;
            }
        }
    
        private bool _efficiencyBarChanged = false;
        //Now you know if it was ever changed, period
        //even if it got changed back to the default value
        public bool IsBarAtDefaultValue
        {
            get
            {
                return !_efficiencyBarChanged;
                //if you preferred, this could still be an equality-like test
                //but keeping track of a state change in a bool value makes more sense to me
            }
        }
    }
