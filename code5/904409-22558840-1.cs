    ....
    for (int i = 0; i < 50; i++)
    {
        if (i > 0)
        {
              guess = guess2;
              guess2 = calc3.InterestRate;
        }
        InterestRate = secantInterestRate(guess, guess2, form);
    ...
