    [PersistentAlias("ShortTermDebt + LongTermDebt / EquityTotal")]
    public decimal DebtEquity
    {
        get
        {
            try
            {
                return decimal.Parse(EvaluateAlias("DebtEquity").ToString());
            }
            catch (DivideByZeroException)
            {
                return 0;  // return 0 or whatever number you want when EquityTotal is equal to zero
            }
        }
    }
