    private bool CalculateLuhnAlgorithm()
    {
        if(this.number.Length % 2 != 0)
            return false; // Or maybe throw an exception?
        if (_cardType != CardType.Unavailable)
        {
            int sumOfAllValues = 0;
            //odd numbers minus the check Digit. 
            for (int i = 0; i < this._number.Length; i++)
            {
                if(i%2 != 0) // because i is 0 based instead of 1 based.
                    sumOfAllValues += (int)char.GetNumericValue(this._number[i])
                else
                {
                    int number = (int)char.GetNumericValue(this._number[i]) * 2;
                    if (number >= 10)
                    {
                        number = (number % 10) + 1;
                    }
                    sumOfAllValues += number;
                }
            }
            // get the luhn validity
            return (sumOfAllValues %10) == 0;
        }
        else
        {
             // Not completely sure what this should do, 
             // but in your code it just results in true.
             return true;
        }
    }
