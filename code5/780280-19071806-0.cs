    static int recCount = 0;
    private void combGenerator(int currEl, int begVal)
    {
            //setting a variable
            for (int c = begVal; c <= currEl + totalCells - maxCells; c++)
            {
                while (genBlock && !abortTime and recCount < 1)
                {
                    if (abortTime)
                        return;
                }
                genBlock = true;//blocks itself
                recCount ++;
                //some recursive stuff happens,
                //because of which I was forced to use a thread instead of timers
              //after all the stuff is done
            recCount--;
        }
    }
