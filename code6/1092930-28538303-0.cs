    public List<int> Factor(int number)
    {
        List<int> factors = new List<int>();
        number = Convert.ToInt32(txtFactorThis.Text);
        int max = (int)Math.Sqrt(number);  
        for (int factor = 1; factor <= max; ++factor)
        { 
            if (number % factor == 0)
            {
                factors.Add(factor);
                if (factor != number / factor)
                { 
                    factors.Add(number / factor);
                }
            }
        }
        string stringfactors = string.Join(",", factors.ToArray());
        txtPrimeFactors.Text = stringfactors;
        
        this.FactorsData = factors;
        return factors;
    }
