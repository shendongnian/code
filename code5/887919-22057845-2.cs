    static void Main(string[] args)
    {
        DiceRoll rollDice = new DiceRoll();
        Random dice1 = new Random();                    //dice 1
        Random dice2 = new Random(dice1.Next(0,100));                    //dice 2
        int len = 36000;
        ...
     }
