    [CompilerGenerated]
    [StructLayout(LayoutKind.Auto)]
    private struct <Example>d__0 : IAsyncStateMachine
    {
    	public int <>1__state;
    	public AsyncTaskMethodBuilder <>t__builder;
    	public Form1 <>4__this;
    	public string <barResult>5__1;
    	private TaskAwaiter<string> <>u__$awaiter2;
    	private object <>t__stack;
    	void IAsyncStateMachine.MoveNext()
    	{
    		try
    		{
    			int num = this.<>1__state;
    			if (num != -3)
    			{
    				TaskAwaiter<string> taskAwaiter;
    				if (num != 0)
    				{
    					this.<>4__this.Foo();
    					taskAwaiter = this.<>4__this.BarAsync().GetAwaiter();
    					if (!taskAwaiter.IsCompleted)
    					{
    						this.<>1__state = 0;
    						this.<>u__$awaiter2 = taskAwaiter;
    						this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Form1.<Example>d__0>(ref taskAwaiter, ref this);
    						return;
    					}
    				}
    				else
    				{
    					taskAwaiter = this.<>u__$awaiter2;
    					this.<>u__$awaiter2 = default(TaskAwaiter<string>);
    					this.<>1__state = -1;
    				}
    				string arg_92_0 = taskAwaiter.GetResult();
    				taskAwaiter = default(TaskAwaiter<string>);
    				string text = arg_92_0;
    				this.<barResult>5__1 = text;
    				this.<>4__this.Baz(this.<barResult>5__1);
    			}
    		}
    		catch (Exception exception)
    		{
    			this.<>1__state = -2;
    			this.<>t__builder.SetException(exception);
    			return;
    		}
    		this.<>1__state = -2;
    		this.<>t__builder.SetResult();
    	}
    	[DebuggerHidden]
    	void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine param0)
    	{
    		this.<>t__builder.SetStateMachine(param0);
    	}
    }
