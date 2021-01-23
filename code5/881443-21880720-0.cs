    var result = DiceWebAPI.PlaceAutomatedBets(
                Session, baseBet, guessLow, guessHigh,
                betCount > Session.MaxBetBatchSize ? Session.MaxBetBatchSize : betCount,
                resetOnWin, resetOnLoss,
                increaseOnWin, increaseOnLoss,
                maxBet, resetOnMaxLoss, stopOnMaxLoss, stopMaxBalance);
