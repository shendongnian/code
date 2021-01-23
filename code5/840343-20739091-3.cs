    public static void Contract_ContractFailed(object sender,  ContractFailedEventArgs e)
    {
        if (e.FailureKind == ContractFailureKind.Invariant)
        {
            e.SetHandled();
            throw new E(e.Message, e.OriginalException);
        }
    }
