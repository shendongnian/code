           private object selectedItem;
           public object SelectedItem
            {
             get { return selectedItem; }
             set 
             { 
                selectedItem = value; 
                if(SelectedItem!= null)
                {
                    IsItemSelected = true;
                    if (IsRadioButtonChecked)
                        BtnEnabled = true;
                }
            }
        }
