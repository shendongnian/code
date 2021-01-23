                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AboveAircraft"));
                    if (_above < _below)
                    {
                         _below = AboveAircraft;
                         PropertyChanged(this, new PropertyChangedEventArgs("BelowAircraft"));
                    }
                }
