    public class StatBarViewModel : AnimatedViewModelBase
    {
        private int MAXIMUMWIDTHFROMVIEW;
        private int _max;
        public StatBarViewModel(int WIDTH, int maxValue)
        {
           _max = maxValue;
           MAXIMUMWIDTHFROMVIEW = WIDTH;
        }
    
        private int _current;
        public int Current 
        { 
            get { return _current; } 
            set 
            { 
                // makes sure value is never greater than max value
                _current = (value > _max) ? _max : value;  
                NotifyOfPropertyChange("Current");
            } 
        } 
    }
