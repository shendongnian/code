    private void Add(Dictionary<int, PaymentResult> PaymentResults, int index, PaymentResult pResult)
    {
        if(PaymentResults.ContainsKey(index))
        {
            PaymentResults[index] = pResult;
        }
        else
        {
            PaymentResults.Add(index, pResult);
        }
    }
