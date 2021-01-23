        for (int i = 4550; i < 4560; i++)
        {
            int sum = 0;
            for (int j = 0; j < i.ToString().Length; j++)
            {
                var c = i.ToString()[j];
                var x = Convert.ToInt32(c);
                sum += pows[x]; 
            }
        }
