    // pow with desired Nan
	public double Pow(double x,double y){
		double MyNaN = 0; // or any desired value for Nan
		double result = MyNaN; 
		if (Math.Floor (y) != y) { // if y is fractional number
			if (x < 0)  // if x is negative number
				return result;
		}
		result = Math.Pow (x, y);
		return result;
	}
