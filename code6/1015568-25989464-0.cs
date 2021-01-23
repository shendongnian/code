    int[] Rolls = { 0, 0, 0, 0, 0, 0 }; // 1 dice = 6 possible rolls 1- 6
    void RollDice() {
        int randomRoll = GetRandomDiceRoll(); //assume this returns 1-6 for the roll
        
        //We use randomRoll-1 becuase the array is zero-indexed E.g. 0-5
        Rolls[randomRoll-1]++;
        //This increments the value and if the roll was 3 for instance your array will look like
        // { 0, 0, 1, 0, 0, 0 }
        
    }
