    public class Signalstrength : ObservableObject
        {
            private PositionStatus _state;      
    
            public PositionStatus State
            {
                get { return _state; }
                set 
                {
                    _state = value;
                    Set("State", ref _state, value);
                }
            }
        }
