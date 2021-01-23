	var negativeBasedArray = Array.CreateInstance(typeof(Int32),
        new []{2}, // array of array sizes for each dimension
        new []{-1}); // array of lower bounds for each dimension
	Console.WriteLine(negativeBasedArray.GetType()); // System.Int32[*]
	negativeBasedArray.SetValue(123, -1);
	negativeBasedArray.SetValue(456, 0);
	foreach(var i in negativeBasedArray)
	{
		Console.WriteLine(i);
	}
	// 123
    // 456
	Console.WriteLine(negativeBasedArray.GetLowerBound(0)); // -1
	Console.WriteLine(negativeBasedArray.GetUpperBound(0)); // 0
