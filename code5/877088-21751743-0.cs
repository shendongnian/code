    for (int iTeller = 0; iTeller < bits.Count(); iTeller++)
        {
            if (bits[iTeller] == 1)
            {
                
                Checkbox ckh= this.Controls.Find("Led" & iTeller, true).FirstOrDefault() as Checkbox;
                Checkbox.Background = Brushes.Green;
            }
        
        }
