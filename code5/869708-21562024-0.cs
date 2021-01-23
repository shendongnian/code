        static decimal GetNumOfDigits(decimal dTest)
        {
            decimal dAnswer = 1;
            decimal dIncrement = 10;
            decimal dMaxIncrement = 10000000000000000000000000000M; //This is how big the number can get before it overflows when multiplied by 10.
            if (dTest < 0) //Another silly but easy way to flip the sign. Could of used Math.Abs but I did not feel like it, xD.
            {
                dTest *= -1;
            }
            while (true)
            {
                if (dTest >= dIncrement)
                {
                    dAnswer++;
                    if (dIncrement == dMaxIncrement)
                    {
                        return (dAnswer);
                    }
                    dIncrement *= 10;
                }
                else
                {
                    return (dAnswer);
                }
            }
        }
