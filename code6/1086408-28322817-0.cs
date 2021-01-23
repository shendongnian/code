    public bool PlaceBet(int Amount, int Dog)
    {
        //1.Place a new bet and store it in my bet field
        this.MyBet = new Bet();   // EMPTY BET
        //2.Return true if the guy had enough money to bet
        if (Cash >= Amount)
        {
            Cash = Cash - Amount; // Remove the amount bet
            MyBet.Amount = Amount;
            MyBet.Dog = Dog;
            MyBet.Bettor = this;
            UpdateLabels();
            return true;
        }
        else if (Cash < Amount)
        {
            // THE BET REMAINS EMPTY
            return false;
        }
        else
        {
            return false;
        }
    }
