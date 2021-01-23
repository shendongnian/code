    var leds = new CheckBox[] { Led0, Led1, Led2, Led3, Led4, Led5, Led6, Led7 };
    for (int iTeller = 0; iTeller < bits.Count(); iTeller++)
    {
        if (bits[iTeller] == 1)
        {
            leds[iTeller].Background = Brushes.Green;
        }
        
     }
