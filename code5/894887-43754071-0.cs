            public static int CalculateTrailingZeroes(BigInteger bigNum)
        {
            int zeroesCounter = 0;
            while (bigNum % 10 == 0)
            {
                zeroesCounter++;
                bigNum /=10;
            }
            return zeroesCounter;
        }
