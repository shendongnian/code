    private void Add(Dictionary<int, PaymentResult> PaymentResults, int index, PaymentResult pResult)
    {
        if(PaymentResult.ContainsKey(index))
        {
            PaymentResult[index] = pResult;
        }
        else
        {
            PaymentResult.Add(index, pResult);
        }
    }
