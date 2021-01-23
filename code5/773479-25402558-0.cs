    public static T LerpMinMax<T>(Numeric<T> input, Numeric<T> inputMin, Numeric<T> inputMax, Numeric<T> outputMin, Numeric<T> outputMax)
    {
         if (input <= inputMin)
         {
            return outputMin;
         }
         else if (input >= inputMax)
         {
            return outputMax;
         }
         return outputMin + ((input - inputMin) / (inputMax - inputMin)) * (outputMax - outputMin);
    }
