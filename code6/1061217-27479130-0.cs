    sample.palindrome();
    sample.isPalindrome();
    Stopwatch sw = Stopwatch.StartNew();
    for (int i = 0; i < 1000; i++)
    {
        sample.palindrome();
        Console.WriteLine("palindrome test #{0} result: {1}", i, sw.ElapsedMilliseconds);
    }
    sw.Stop();
    Console.WriteLine("palindrome test Final result: {0}", sw.ElapsedMilliseconds);
    sw.Restart();
    for (int i = 0; i < 1000; i++)
    {
        sample.isPalindrome();
        Console.WriteLine("isPalindrome test #{0} result: {1}", i, sw.ElapsedMilliseconds);
    }
    sw.Stop();
    Console.WriteLine("isPalindrome test Final result: {0}", sw.ElapsedMilliseconds);
