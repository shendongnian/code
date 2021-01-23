    static void xn()
    {
        double r = 3.9;
        var n = 0;
        var x_arr = new double[100]; 
        // I think the number of elements may be 101.
        // and you will get an IndexOutOufRangeException.
        //var x_list = new List<double>(); // alternative.
        for (double x = 0; x <= 1; x+= 0.01)
        {
            double xr = r * x * (1 - x);
            x_arr[n++] = xr;
            // x_list.Add(xr); // alternative.
        }
        for (int y = 0; y <23; y++) 
        { 
            Console.WriteLine(xr_arr[y]);
            // Console.WriteLine(xr_list[y]); alternative.
        }
    }
