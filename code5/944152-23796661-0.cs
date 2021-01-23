    <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
        <alias alias="WrappedFund" type="TestUnityIssue.Wrapper`1[[TestUnityIssue.Fund, TestUnityIssue, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], TestUnityIssue, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" />
        <namespace name="TestUnityIssue" />
        <assembly name="TestUnityIssue" />
        <container>
            <register type="IReader[Fund]" mapTo="FundReader" />
            <register type="IReader[WrappedFund]" mapTo="WrappedFundReader" />
        </container>
    </unity>
