        public enum State
        {
            Inactive,
            Active,
        }
        public class Service
        {
            private readonly ObservableCollection<State> _states = new ObservableCollection<State>() { State.Inactive, State.Active };
            private int _selectedValue;
            public int SelectedValue
            {
                get { return _selectedValue; }
                set { _selectedValue = value; }
            }
            public ObservableCollection<State> States
            {
                get { return _states; }
            }
        }
