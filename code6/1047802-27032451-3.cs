     public static string NextValue(string Counting)
        {
            int nextVal;
            if(int.TryParse(Counting, out nextVal))
            {
                return (nextVal + 1).ToString();
            }
            else 
            {
                char[] numbers = Counting.ToCharArray();
                StringBuilder incremented = new StringBuilder();
                foreach (char digit in numbers.Reverse())
                {
                    if (digit == 'z')
                    {
                       incremented.Append("0");
                    }
                    else if (int.TryParse(digit.ToString(), out nextVal))
                    {
                        nextVal = nextVal + 1;
                        if (nextVal == 10)
                        {
                            incremented.Append("z");
                        }
                        else
                        {
                            incremented.Append(nextVal.ToString());
                        }
                        
                        incremented.Append(string.Concat(numbers.Reverse().Skip(incremented.Length)));
                        break;
                    }
                    else
                    {
                        //Invalid character in number except for z
                        return string.Empty;
                    }
                }
                if (incremented[incremented.Length - 1] == '0')
                    incremented.Append("1");
                return Reverse(incremented.ToString()); 
            }    
        }
    
         public static string Reverse(string s)
         {
             char[] charArray = s.ToCharArray();
             Array.Reverse(charArray);
             return new string(charArray);
         }
