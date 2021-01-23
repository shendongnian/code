    static IEnumerable<int> Spartans()
    {
        for(int i = 0; i < 300; i++)
        {
            if(i % 30 == 0)
                Console.WriteLine("30 More!");
            
            yield return i;            
        }
    }
