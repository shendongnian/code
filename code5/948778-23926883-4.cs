    Example(11, 2); //result = 2
    private static void Example(int TotalLimit, int incBy)
        {
            int ExtraLife = 0;
            int LastIncrement = 0;
            for (int TotalScore = 1; TotalScore <= TotalLimit; TotalScore += incBy)
            { 
                int inc = TotalScore / 5;
                if (inc > LastIncrement)
                {
                    ExtraLife++;
                    LastIncrement = inc;
                }                
            }           
        }
