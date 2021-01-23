    public class Trigger
    {
        private bool _trigger;
    
        public bool Trigger
        {
            get 
            { 
                var val = _trigger;
                _trigger = false;
                return val;
            }
            set { _trigger = value; }
        }
    }
