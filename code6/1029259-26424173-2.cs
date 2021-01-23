    Dictionary<int, dynamic> MAPS = new Dictionary<int, object>
    {
        {1, new { a = 1, b = 2, c = 3} as dynamic}
    };
            
    Console.WriteLine(MAPS[1].b); //prints 2
