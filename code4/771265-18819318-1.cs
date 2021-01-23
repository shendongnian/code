	Refable<double> rd1 = new Refable<double>(1.5);
	Refable<double> rd2 = d1;
	// get initial value
	double d1 = rd1;
	// set value to 2.5 via second reference
	rd2.Value = 2.5;
	// get current value
	double d2 = rd1;
	// Output should be: 1.5, 2.5
	Console.WriteLine("{0}, {1}", d1, d2);
