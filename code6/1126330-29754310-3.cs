    internal override IEnumerable<ODataAction> GetActions()
    {
        DebugUtils.CheckNoExternalCallers();
        return ODataUtilsInternal.ConcatEnumerables(this.entryMetadataContext.Entry.NonComputedActions, this.MissingOperationGenerator.GetComputedActions());
    }
