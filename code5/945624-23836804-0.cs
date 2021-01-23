	int[] nums = { 1, -2, 3, 0, -4, 5 };
	
	Console.WriteLine("Before query creation");
	
	var posNums = nums.Where(n => { Console.WriteLine("   Evaluating " + n); return n > 0; });
	
	Console.WriteLine("Before foreach 1");
	
	foreach (int i in posNums)
		Console.WriteLine("   Writing " + i);
	
	Console.WriteLine("Before array modification");
	
	nums[1] = 99;
	
	Console.WriteLine("Before foreach 2");
	
	foreach (int i in posNums)
		Console.WriteLine("   Writing " + i);
