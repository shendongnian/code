            get { return _Ricambi; }
            set
            {
                _Ricambi = value; _Totale = _Ricambi + _Manifattura; RaisePropertyChanged("Ricambi"); RaisePropertyChanged("Totale");
            }
        }
        public double Manifattura
        {
            get { return _Manifattura;  }
            set { _Manifattura = value;_Totale = _Ricambi + _Manifattura; RaisePropertyChanged("Manifattura"); RaisePropertyChanged("Totale"); }
        }
       
        
        public double Totale
        {   
            get { return _Totale; }
        }
