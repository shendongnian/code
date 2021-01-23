    public void Calculate(IDictionary<BigInteger, ExponentialResult> dictionary)
    {
        SortedList<BigInteger, ExponentialResult> list = new SortedList<BigInteger, ExponentialResult>(dictionary, new BigIntegerComparer());
        foreach (KeyValuePair<BigInteger, ExponentialResult> kv1 in list)
        {
            foreach (KeyValuePair<BigInteger, ExponentialResult> kv2 in list)
            {
                ExponentialResult sum;
                if (list.TryGetValue(BigInteger.Add(kv1.Key, kv2.Key), out sum))
                {
                   //we have found one such that a^x + b^y = c^z
                }
                if (kv1 == kv2)
                {
                    break;
                } 
            }
        }
    }
