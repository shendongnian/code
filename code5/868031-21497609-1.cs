    public static int continuousZeros(int x)
    {
        int max = 0;
        int current = 0;
        char[] charArray = x.ToString().ToCharArray();
        for (int i = 0; i < charArray.Length; i++)
        {
            if (charArray[i] == '0')
            {
                current++;
            }
            else
            {
                if (current > max) { max = current; }
                current = 0;
            }
        }
      
        return max;
    }
