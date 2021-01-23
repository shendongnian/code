        public string Print
        {
            get { return _newMsg; }
            set
            {
                _newMsg = value;
                AddToHistory(_newMsg);  // this and next line were swapped
                RaisePropertyChangedEvent("History");                
            }
        }
