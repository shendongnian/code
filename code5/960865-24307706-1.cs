     int ageValue;
     if(!Int32.TryParse(ageBox.Text, out ageValue))
     {
         MessageBox.Show("Please type a valid value for Age!");
         return;
     }
     .... insert code follows...
