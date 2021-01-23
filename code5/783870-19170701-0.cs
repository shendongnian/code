    public class ResultStatus
    {
         public ResultStatus(DTGenericCode[] basicStatus, DTGenericCode[] arStatus)
         {
             this.BasicStatus = basicStatus;
             this.ARStatus = arStatus;
         }
         public DTGenericCode[] BasicStatus { get; private set; }
         public DTGenericCode[] ARStatus { get; private set; }
    }
    public Task<ResultStatus> GetCaseStatusAsync(int CaseOID, int ClientOID)
    {
         var tcs = new TaskCompletionSource<ResultStatus>();
         theClass.BeginGetCaseStatus(CaseOID, ClientOID, iar =>
                 {
                     DTGenericCode[] bs;
                     DTGenericCode[] as;
                     theClass.EndGetCaseStatus(iar, out bs, out as);
                     tcs.SetResult(new ResultStatus(bs, as));
                 }, null);
         return tcs.Task;
    }
