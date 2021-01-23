    void Main(string[] args)
    {
        var amount = 6;
    
        var availabeCoins = new List<CoinPack>
        { 
            new CoinPack { Value = 500, Amount = 0 },
            new CoinPack { Value = 100, Amount = 0 },
            new CoinPack { Value = 50, Amount = 0 },
            new CoinPack { Value = 20, Amount = 0 },
            new CoinPack { Value = 10, Amount = 0 },
            new CoinPack { Value = 5, Amount = 1 },
            new CoinPack { Value = 2, Amount = 3 },
            new CoinPack { Value = 1, Amount = 0 }
        };
        
        var usedCoins = new List<CoinPack>
        { 
            new CoinPack { Value = 500, Amount = 0 },
            new CoinPack { Value = 100, Amount = 0 },
            new CoinPack { Value = 50, Amount = 0 },
            new CoinPack { Value = 20, Amount = 0 },
            new CoinPack { Value = 10, Amount = 0 },
            new CoinPack { Value = 5, Amount = 0 },
            new CoinPack { Value = 2, Amount = 0 },
            new CoinPack { Value = 1, Amount = 0 }
        };
        
        Change(amount, availabeCoins, usedCoins);
        foreach (var usedCoin in usedCoins)
        {
            Console.WriteLine(usedCoin.Value + " " + usedCoin.Amount);
        }
    }
    
    List<CoinPack> Change(int amount, List<CoinPack> availableCoins, List<CoinPack> usedCoins)
    {
        if (amount == 0)
        {
            return availableCoins;
        }
        
        if (amount < 0)
        {
            return null;
        }
        
        foreach (var availableCoin in availableCoins.Where(ac => ac.Amount > 0 && amount >= ac.Value))
        {
            var newAvailableCoins = CopyCoins(availableCoins);
            newAvailableCoins.First(c => c.Value == availableCoin.Value).Amount--;
            var change = Change(amount - availableCoin.Value, newAvailableCoins, usedCoins);
            
            if (change == newAvailableCoins)
            {
                usedCoins.First(c => c.Value == availableCoin.Value).Amount++;
                return availableCoins;
            }
        }
        
        return null;
    }
    
    List<CoinPack> CopyCoins(List<CoinPack> coinPacks)
    {
        var copy = new List<CoinPack>();
        foreach (var coinPack in coinPacks)
        {
            copy.Add(new CoinPack { Value = coinPack.Value, Amount = coinPack.Amount });
        }
        return copy;
    }
    
    class CoinPack
    {
        public int Value;
        public int Amount;
    }
