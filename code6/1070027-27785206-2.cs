    public void OperationMethod(ISomeOperationService service)
    {
       // "method parameter injection"
    }
    using (var op = BeginOperationScope())
    {
       op.ExecuteMethod(OperationMethod);
    }
