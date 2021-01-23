    for (int iTeller = 0; iTeller < bits.Count(); iTeller++)
                {
                    if (bits[iTeller] == 1)
                    {
                        var myCheckbox = (CheckBox)this.FindName("Led" + iTeller);
                        myCheckbox.Background = Brushes.Green;
                    }
    
                }
