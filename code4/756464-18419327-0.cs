    public List<Operation> Operations { get; set; }
    public IEnumerable<int> OperationIDs
    {
        get
        {
            return Operations.Select(op => op.OperationID);
        }
    }
