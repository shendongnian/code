    class foo
    {
        public static string ToRep(int Year,int Num)
        {
            StringBuilder SB = new StringBuilder(Year.ToString());
            SB.Append(":");
            int DecPart = Num % 1000;
            int Base26Part = Num / 1000;            
            for(int x = 0 ; x < 3 ; x++)
            {
                char NewChar =(char)( 'A'+ Base26Part % 26); 
                Base26Part /= 26;                
                SB.Insert(3,NewChar); 
            }
            SB.Append(DecPart.ToString("000"));
            return SB.ToString(); 
        }
    }
