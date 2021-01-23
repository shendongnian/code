    public void mood()
            {
                var unhappiness = Hunger + Boredom;
                string m = string.Empty;
                if (unhappiness < 5)
                {
                    m = "Happy";
                }
    
                if (unhappiness <= 5 && 
                    unhappiness <= 10)
                {
                    m = "Okay";
                }
    
                if (unhappiness <= 11 &&
                    unhappiness <= 15)
                {
                    m = "Frustrated";
                }
    
                if (unhappiness <= 16)
                {
                    m = "Mad";
                }
                return m;
