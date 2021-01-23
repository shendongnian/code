    public Dictionary<Coin, int> GetCoins(int balance)
    {
        var result = new Dictionary<Coin, int>();
        
        foreach (var pair in repository) {
            while (balance - pair .Key.Worth>0 && pair.Value>0 )
            {
                balance -= pair.Key.Worth;  
                pair.Value--;              
                if (!result.ContainKey(coin.key)) result[pair.key] = 0;
                result[coin.key]++;
            } 
            if (balance == 0) break;
        }
        
        if (balance == 0) { 
            // pair is a struct, so repository does not change when pair.Value is modified,
            // so if we find a solution, repository has to be updated
            foreach (var pair in result) repository[pair.key] -= pair.Value;
            return result;
        }
        return null;
    }
