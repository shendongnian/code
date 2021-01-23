    public String GetFeeId(CodeActivityContext executionContext)
    {
        // Create the context
        var context = executionContext.GetExtension<IWorkflowContext>();
        var feeRecordId = context.PrimaryEntityId
    }
