    int numberOfIterations = 1000; // you decide on a reasonable threshold.
    Stopwatch sw = new Stopwatch();
    sw.Start();
    for(int i = 0 ; i < numberOfIterations ; i++)
    {
       sample.palindrome(); // why console write?
    }
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds); // or sw.ElapsedMilliseconds/numberOfIterations 
