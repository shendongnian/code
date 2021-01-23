    [ContractInvariantMethod]
    private void ObjectInvariant()
    {
        Contract.Invariant(MyPropertyCollection.All(x => x != null));
    }
