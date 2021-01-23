    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    class Solution
    {
        public int solution(string S)
        {
            int highestCount = 0;
    
            for (var i = S.Length; i > 0; i--)
            {
                int occurs = 0;
                string prefix = S.Substring(0, i);
                int firstIndex = S.IndexOf(prefix);
                if (firstIndex >= 0)                
                    occurs++;
                
    
                var tempString = S;
                int tempIndex = firstIndex + 1;
                while ((tempIndex >= 0))
                {
                    tempString = tempString.Substring(tempIndex);
                    tempIndex = tempString.IndexOf(prefix);
                    if (tempIndex >= 0)
                    {
                        tempIndex++;
                        occurs++;
                    }
                }
    
                var product = occurs * prefix.Length;    
                if ((product) > highestCount)                
                    highestCount = product;
                
           }
    
            return highestCount;
    
    
        }
    }
