    private void buttonclick(object sender, EventArgs e)
        {
            IEnumerable<int> range = Enumerable.Range(1,10000);
            var qry = TestSlowLoadingEnumerable(range);
            //We begin the call and give it our callback delegate
            //and a delegate to an error handler
            AsynchronousQueryExecutor.Call(qry, HandleResults, HandleError, OnFirstItem);
       }
    
