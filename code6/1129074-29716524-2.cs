    static void xn()
    {
        double r = 3.9;
        var n = 0;
        // I think the number of elements could (theoretically) be different from 100
        // and you could get an IndexOutOufRangeException if it is 101.
        var increment = 0.01d;  // 1.0d/300.0d; // <== try this.
        var n_expected = 100;   // 300 // <= with this.
        var x_arr = new double[n_expected]; 
        // alternative: if you cannot be absolutely certain about the number of elements.
        //var x_list = new List<double>(); 
        for (double x = 0; x <= 1; x += increment)
        {
            double xr = r * x * (1 - x);
            x_arr[n++] = xr;
            // x_list.Add(xr); // alternative.
        }
        for (int y = 0; y <23; y++) 
        { 
            Console.WriteLine(xr_arr[y]);
            // Console.WriteLine(xr_list[y]); // alternative.
        }
    }
