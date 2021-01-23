    public void Main()
    {
        ADODB.Recordset result = (ADODB.Recordset) Dts.Variables["result"].Value;
        int rowCount = result.RecordCount;
        
        Dts.TaskResult = (int)ScriptResults.Success;
    }
