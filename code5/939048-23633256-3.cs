        private bool _StateA;
        private bool _StateB;
        public bool IsStateA { 
          get { return _StateA; }
          set { 
            _StateA = value;
            if (value) _StateB = false; // If this is now true, falsify the other.
          }
        }
        public bool IsStateB { 
          get { return _StateB; }
          set { 
            _StateB = value;
            if (value) _StateA = false; // If this is now true, falsify the other.
          }
        }
