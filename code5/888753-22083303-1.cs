    public static int CalculateRelation(int input, int inputMin, int inputMax, int outputMin, int outputMax)
    {
        //Making sure bounderies arent broken...
        if (input > inputMax)
        {
            input = inputMax;
        }
        if (input < inputMin)
        {
            input = inputMin;
        }
        //Return value in relation to min og max
        double position = (double)(input - inputMin) / (inputMax - inputMin);
        int relativeValue = (int)(position * (outputMax - outputMin)) + outputMin);
        return relativeValue;
    }
