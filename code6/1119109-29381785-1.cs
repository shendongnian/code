    for (int i = 0; i < 10; i++) 
    {
        double randNum = mRandom.NextDouble();             
        if (randNum < probRed) 
        { 
            probArr[i] = RED_MARBLE; 
        }
        else if (randNum < (probRed + probGreen)) 
        {
            probArr[i] = GREEN_MARBLE; 
        }
        else if (randNum < (probRed + probGreen + probBlue)) 
        {
            probArr[i] = BLUE_MARBLE; 
        }
        else  
        { 
            probArr[i] = ORANGE_MARBLE; 
        }
    }
