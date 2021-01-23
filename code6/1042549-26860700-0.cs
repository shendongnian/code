    class ChequeItemVM
    {
        //Properties
        public ChequeItemVM()
        {
        }
        public ChequeItemVM( Cheque chq)
        {
            AccountNumber = chq.ACCNTNO;
            Ammount = chq.AMCHQ;
            BankId = chq.CDBNK;
            Branch = chq.CDSHB;
            BranchName = chq.DESC;
            ChequeDate = chq.DTCHQ;
            ChequeID = chq.IDCHQ;
            ChequeNumber = chq.NOCHQ;
            CurrencyAmount = chq.CONVRATE;
            CurrencyCode = chq.CDARZ;
            RejectDate = chq.BCKDTCHQ;
        }
    }
