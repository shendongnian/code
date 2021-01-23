     static Array Factors(double value)
        {
            List<int> factors = new List<int>();
        
            for (int i = 1; i <= value; i++)
            {
                if (value % i == 0)
                    factors.Add(i);            
            }
            return factors.ToArray();
        }
