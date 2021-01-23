    public class CalcTest
    { 
        public void uniform(ref string[] numbers)
        {
            string[] ret = new string[numbers.Length];
    
            for(int i = 0; i < numbers.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
    
                for(int j = 0; j < number.Length; j++)
                {
                    char c = number[j];
                    if(!char.IsLetterOrDigit(c))
                    {
                        sb.Append('.');
                    }
                    else if (char.IsWhitespace(c))
                    {
                        sb.Append(',');
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
                ret[i] = sb.ToString(); 
            }
            numbers = ret;
        }  
    }         
