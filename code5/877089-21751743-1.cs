    for (int iTeller = 0; iTeller < bits.Count(); iTeller++)
        {
            if (bits[iTeller] == 1)
            {
                   object i = this.FindName("Led" & iTeller);
                   if (i is CheckBox) 
                  { 
                    CheckBox k = (CheckBox)i;
                    MessageBox.Show(k.Name);
                  }
                
               }
        
        }
