    var dice = ShortForm(new[]{result.D1, result.D2, result.D3});
    var betGoodCount = bets.Count(bet => BetInDice(bet, dice));
    Dictionary<int, int> ShortForm(IEnumerable<Dice> dice)
    {
       return dice
          .GroupBy(die => die.FaceValue)
          .ToDictionary(group => group.Key, group => group.Count);
    }
    bool BetInDice(Bet bet, Dictionary<int, int> dice)
    {
      return ShortForm(bet.Dice)
        .All(pair => dice.ContainsKey(pair.Key) && pair.Value <= dice[pair.Key];
    }
    
