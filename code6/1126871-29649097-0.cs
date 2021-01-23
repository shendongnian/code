     public bool CheckBox1
        {
            get { return _checkBox1; }
            set 
            { 
                _checkBox1 = value;
                if (value == true)
                {
                    CheckBox2 = false;
                }
                OnPropertyChanged("CheckBox1");
            }
        }
        private bool _checkBox2 = false;
        public bool CheckBox2
        {
            get { return _checkBox2; }
            set 
            { 
                _checkBox2 = value;
                if (value == true)
                {
                    CheckBox1 = false;
                }
                OnPropertyChanged("CheckBox2");
            }
        }
