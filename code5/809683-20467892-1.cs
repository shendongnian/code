    using System;
    
    class Solution
    {
        public int solution(string S)
        {
        int highestCount = 0;
        for (var i = S.Length; i > 0; i--)
        {
            int occurs = 0;
            string prefix = S.Substring(0, i);    
            int tempIndex = S.IndexOf(prefix) + 1;             
            string tempString = S;            
            
            while (tempIndex > 0)
            {
                tempString = tempString.Substring(tempIndex);
                tempIndex = tempString.IndexOf(prefix);                                
                tempIndex++;
                occurs++;                                          
            }
            int product = occurs * prefix.Length;
           
            if ((product) > highestCount)
            {
                if (highestCount >  1000000000)              
                    return 1000000000;                           
                highestCount = product;
            }
        }
          
        return highestCount;
    }
    }
