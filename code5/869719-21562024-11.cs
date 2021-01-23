        static int GetNumOfDigits(decimal dTest)
        {
            int     nAnswer = 1;
            decimal dIncrement = 10;
            //This is how big the number can get before it overflows
            //when multiplied by 10.
            decimal dMaxIncrement = 10000000000000000000000000000M; 
            dTest = Math.Abs(dTest);
            while (true)
            {
                if (dTest >= dIncrement)
                {
                    nAnswer++;
                    //Return if increment reaches max value before overflow.
                    if (dIncrement == dMaxIncrement)
                    {
                        return (nAnswer);
                    }
                    dIncrement *= 10;
                }
                else
                {
                    return (nAnswer);
                }
            }
        }
