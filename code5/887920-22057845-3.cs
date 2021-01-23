    static void Main(string[] args)
    {
        DiceRoll rollDice = new DiceRoll();
        Random dice1 = new Random();                    //dice 1
        System.Threading.Thread.Sleep(100);             //get a different seed for dice 2
        Random dice2 = new Random();                    //dice 2
        int len = 36000;
        ...
     }
