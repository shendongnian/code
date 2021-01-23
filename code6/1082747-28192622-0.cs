    void Main()
    {
    	var foo = new Foo();
        //type parameter here defines the type of the Task
        //so here, we're expecting to make a Task<int>
    	var tcs = new TaskCompletionSource<int>();
    	foo.Evt += (sender, eventArgs) => {
    		tcs.SetResult(0);
            //or tcs.SetException(someException);
            //etc...
    	};
        //here's your task, ready to go.
    	Task<int> task = tcs.Task;
    }
    class Foo
    {
    	public event EventHandler Evt;
    }
