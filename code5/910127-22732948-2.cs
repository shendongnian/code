    static void Main(string[] args)
    {
        // It's just a declaration; no value assigned to boardOne; boardOne contains trash
        ThreeD boardOne;                                                                        
        // It's just a declaration; no value assigned to boardTwo; boardTwo contains trash 
        ThreeD boardTwo;                                                                  
        // It's just a declaration; no value assigned to boardThree; boardThree contains trash
        ThreeD boardThree;                                                                      
        ....   
        if (randomNum == 1)                                                                     
        {
            Console.WriteLine("You first");
            while (true)
            {
                boardOne.getBoardCells(); // <- And here you're trying to access the trash   
