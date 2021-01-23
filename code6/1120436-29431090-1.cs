        public bool IsRadioButtonChecked
        {
            get { return isRadioButtonChecked; }
            set { 
                isRadioButtonChecked = value;
                if (IsItemSelected && isRadioButtonChecked)
                    BtnEnabled = true;
            }
        }
