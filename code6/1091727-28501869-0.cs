    [Function(Name="dbo.Call me as you want")]
    public ISingleResult<YourTableResult> GetSomething([Parameter(DbType="NVarChar(20)")] string param1)
    {
        IExecuteResult result = this.ExecuteMethodCall(this,         ((MethodInfo)(MethodInfo.GetCurrentMethod())), param1);
        return ((ISingleResult<YourTableResult>)(result.ReturnValue));
    }
