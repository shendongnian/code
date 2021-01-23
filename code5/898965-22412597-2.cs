	public class Class1 : ContextBoundObject
	{
		// ...
		private struct <Method1>d__0 : IAsyncStateMachine
		{
			public int <>1__state;
			public AsyncTaskMethodBuilder <>t__builder;
			public Class1 <>4__this;
			private TaskAwaiter <>u__$awaiter1;
			private object <>t__stack;
            void IAsyncStateMachine.MoveNext()
			{
				try
				{
					int num = this.<>1__state;
					if (num != -3)
					{
						TaskAwaiter taskAwaiter;
						if (num != 0)
						{
							Console.WriteLine(this.<>4__this.one);
							taskAwaiter = Task.Delay(50).GetAwaiter();
							if (!taskAwaiter.IsCompleted)
							{
								this.<>1__state = 0;
								this.<>u__$awaiter1 = taskAwaiter;
								this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, Class1.<Method1>d__0>(ref taskAwaiter, ref this);
								return;
							}
						}
						else
						{
							taskAwaiter = this.<>u__$awaiter1;
							this.<>u__$awaiter1 = default(TaskAwaiter);
							this.<>1__state = -1;
						}
						taskAwaiter.GetResult();
						taskAwaiter = default(TaskAwaiter);
						Console.WriteLine(this.<>4__this.one);
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
            // ... 
		}
		private string one = "1";
        public Task Method1()
		{
			Class1.<Method1>d__0 <Method1>d__;
			<Method1>d__.<>4__this = this;
			<Method1>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<Method1>d__.<>1__state = -1;
			AsyncTaskMethodBuilder <>t__builder = <Method1>d__.<>t__builder;
			<>t__builder.Start<Class1.<Method1>d__0>(ref <Method1>d__);
			return <Method1>d__.<>t__builder.Task;
		}
	}
