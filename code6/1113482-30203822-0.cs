    public decimal RawTotalIncludingTax {get;set;}
    public Money TotalIncludingTax 
    { 
       get { return RawTotalIncludingtax; }
       set { RawTotalIncludingTax = value; }
    }
