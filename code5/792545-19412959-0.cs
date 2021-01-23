    ...
    if (rorbcard.CardNumber > highLow.CardNumber)
    {
        if (inOut.CardNumber > rorbcard.CardNumber) || (inOut.CardNumber < highLow.CardNumber)
        {
            Console.WriteLine("Correct give 6 drinks\n");
        }
        else
        {
            Console.WriteLine("Wrong take 6 drinks\n");
        }
    }
    else if (rorbcard.CardNumber < highLow.CardNumber)
    {
        if (inOut.CardNumber < rorbcard.CardNumber) || (inOut.CardNumber > highLow.CardNumber)
        {
            Console.WriteLine("Correct give 6 drinks\n");
        }
        else
        {
            Console.WriteLine("Wrong take 6 drinks\n");
        }
    }
    break;
    ...
