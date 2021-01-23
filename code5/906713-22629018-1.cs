    [ContractAbbreviator]
    private void DataAndStateUnchanged() 
    {
       Contract.Ensures(this.State == Contract.OldValue(this.State));
       Contract.Ensures(this.Data == Contract.OldValue(this.Data));
    }
