    DiceBag bag = new DiceBag();
    List<int> rolls = bag.RollQuantity( DiceBag.Dice.D20 , 131 );
    for( int i = 0 ; i < rolls.Count ; i++ ) {
       Console.WriteLine( rolls[ i ] );
    }
