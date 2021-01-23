    using System.Threading.Tasks;
    private void simpleMethod()
    {
        lblPleaseWait.Visible = true;
		Cursor.Current = Cursors.WaitCursor;
    	var tsk = Task.Factory.StartNew(() => DoSomeWorkAsync());
    	Task.WaitAll(tsk);
        DataTable table = tsk.Result;
        lblPleaseWait.Visible = false;
		Cursor.Current = Cursors.Default;
    }
