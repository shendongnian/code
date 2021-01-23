    using System.Threading.Tasks;
    private void simpleMethod()
    {
    	var tsk = Task.Factory.StartNew(() => DoSomeWorkAsync());
    	Task.WaitAll(tsk);
        DataTable table = tsk.Result;
    }
