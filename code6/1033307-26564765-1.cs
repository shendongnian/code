    public Dictionary<BigInteger, ExponentialResult> AccumulateRange(int base_min, int base_max, int power_min, int power_max)
    {
        Dictionary<BigInteger, ExponentialResult> dictionary = new Dictionary<BigInteger, ExponentialResult>();
        for (int base = base_min; base <= base_max; ++base)
        {
            for(int power = power_min; power <= power_max; ++power)
            {
                Exponential exp = new Exponential();
                exp.base = base;
                exp.power = power;
                
                BigInteger result = BigInteger.Pow(base, power);
                ExponentialResult set;
                if (!dictionary.TryGetValue(result, out set))
                {
                   set = new ExponentialResult(result);
                   dictionary.Add(result, set);
                }
                set.Add(exp);
            }
        }
    }
