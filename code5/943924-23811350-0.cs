    ILArray<double> vec = ILMath.array(new[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0 });
    Console.WriteLine(vec);
    // create a vector range from index 3-5
    ILArray<int> range = array<int>(2,3,4,5);
    Console.WriteLine(range);
    // modify all values in range
    for (int i = 0; i < 3; i++) // make tree steps. Modify as needed!
        vec[range + i] = vec[range + i] + i;
    Console.WriteLine(range);
    // view modified original vector
    Console.WriteLine(vec);
    
