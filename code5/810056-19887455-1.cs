    public double CalculateCalories(string text, double mass, double time)
    {
        int index = -1;
        //First we find the index we're interested in
        for(int i=0; i < activity.count; i++)
        {
            string act = activity[i].ToString();
            //If we match the string perfectly, then we know the index
            if (act.Equals(text))
            {
                index = i;
            }
        }
        if (index.Equals(-1))
        {
            //error - throw some sort of exception
        }
        //Now that we know the index, we'll determine which arrayList we look for
        double calorieCount  = 0;
        if (mass < 130)
        {
            //take from the small one
            calorieCount = rangeSmall[index];
        }
        else if (//Follow the same pattern)
        {
            //
        }
        //Then multiply it by time somehow - depending on how your multiplier is set up
        return time*calorieCount;
    }
