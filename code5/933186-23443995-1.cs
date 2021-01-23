        Float value = 5000.1234;
	//
	// Invoke BitConverter.GetBytes to convert double to bytes.
	//
	byte[] array = BitConverter.GetBytes(value);
	foreach (byte element in array)
	{
	    Console.WriteLine(element);
	}
	//
	// You can convert the bytes back to a double.
	//
	Float result = BitConverter.Tofloat(array, 0);
	Console.WriteLine(result);
