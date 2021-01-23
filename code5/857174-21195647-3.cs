    public static bool isTwenty(int num)
    {
        for(int j = 1; j <= 20; j++)
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
    
        return true;
    }
