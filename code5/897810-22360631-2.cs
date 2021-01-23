    public class Service
    {
        private State _selectedState;
        private readonly ObservableCollection<State> _states = new ObservableCollection<State>() { new State() { Value = "Active", IsSelected = true} ,new State() {Value = "Inactive" }};
    
        public State SelectedSelectedState
        {
            get { return _selectedState; }
            set
            {
                _selectedState = value;
                BitState = _selectedState.Value == "Active" ? 1 : 0;
            }
        }
        
        public int BitState { get; set; }
    
        public class State
        {
            public bool IsSelected { get; set; }
            public string Value { get; set; }
        }
    
        public ObservableCollection<State> States
        {
            get { return _states; }
        }
    }
