    static void Main(string[] args)
    {
        var amount = 100000;
    
        var availabeCoins = new CoinPack[] 
        { 
            new CoinPack { Value = 500, Amount = 2 },
            new CoinPack { Value = 100, Amount = 3 },
            new CoinPack { Value = 50, Amount = 5 },
            new CoinPack { Value = 20, Amount = 1 },
            new CoinPack { Value = 10, Amount = 2 },
            new CoinPack { Value = 5, Amount = 0 },
            new CoinPack { Value = 2, Amount = 10 },
            new CoinPack { Value = 1, Amount = 500 }
        };
        
        var usedCoins = new CoinPack[] 
        { 
            new CoinPack { Value = 500 },
            new CoinPack { Value = 100 },
            new CoinPack { Value = 50 },
            new CoinPack { Value = 20 },
            new CoinPack { Value = 10 },
            new CoinPack { Value = 5 },
            new CoinPack { Value = 2 },
            new CoinPack { Value = 1 }
        };
    
        for (int i = 0; i < availabeCoins.Length; i++)
        {
            usedCoins[i].Amount = amount / availabeCoins[i].Value;
            if (usedCoins[i].Amount > availabeCoins[i].Amount)
            {
                usedCoins[i].Amount = availabeCoins[i].Amount;
            }
            
            amount -= usedCoins[i].Amount * usedCoins[i].Value;
        }
        
        foreach (var usedCoin in usedCoins)
        {
            Console.WriteLine(usedCoin.Value + " " + usedCoin.Amount);
        }
    }
    
    class CoinPack
    {
        public int Value;
        public int Amount;
    }
