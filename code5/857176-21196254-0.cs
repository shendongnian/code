    public static bool isTwenty(int num)
    {
        for(int j = 1; true; j++)
        {
            if(num % j != 0)
            {
                return false;
            }
            else if(num % j == 0 && num == 20)
            {
                return true;
            }
        }
    }
