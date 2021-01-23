    int maxPalindrome = 0;
    for(int i = 999; i >= 0; i--) 
    {
        for(int j = 999; j >= 0; j--) 
        {
            var p = i * j;
            if (p <= maxPalindrome) 
            {
                break;
            }
            if (IsPalindrome(p)) 
            {
                maxPalindrome = p;
                break;
            }
        }
    }
        
    Console.WriteLine(maxPalindrome);
