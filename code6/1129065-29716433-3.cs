	static void xn()
	{
		string data = "   abc df fd";
		var xr_arr = Build(100);
		Display(xr_arr, 23);
	}
	public static double[] Build(int size)
	{
		double r = 3.9;
		double[] xr_arr = new double[size];
		double step = 1.0/size;
		for (double x = 0; x <= 1; x += step)
		{
			double xr = r*x*(1 - x);
			int index = (int)(x * size);
			xr_arr[index] = xr;
		}
		return xr_arr;
	}
	public static void Display(double[] xr_arr, int size)
	{
		var length = Math.Min(xr_arr.Count(), size);
		for (int y = 0; y < length; y++)
		{
			Console.WriteLine(xr_arr[y]);
		}
	}
