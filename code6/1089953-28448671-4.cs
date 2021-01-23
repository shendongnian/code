        [CompilerGenerated]
        private struct <GetPageLengthAsync>d__0 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<int> <>t__builder;
            private object <>t__stack;
            private TaskAwaiter<string> <>u__$awaiter4;
            public HttpClient <client>5__1;
            public Task<string> <fetchTextTask>5__2;
            public int <length>5__3;
            public string url;
            private void MoveNext()
            {
                int num;
                try
                {
                    bool flag = true;
                    switch (this.<>1__state)
                    {
                        case -3:
                            goto Label_0113;
                        case 0:
                            break;
                        default:
                            this.<client>5__1 = new HttpClient();
                            break;
                    }
                    try
                    {
                        TaskAwaiter<string> awaiter;
                        if (this.<>1__state != 0)
                        {
                            this.<fetchTextTask>5__2 = this.<client>5__1.GetStringAsync(this.url);
                            awaiter = this.<fetchTextTask>5__2.GetAwaiter();
                            if (!awaiter.IsCompleted)
                            {
                                this.<>1__state = 0;
                                this.<>u__$awaiter4 = awaiter;
                                this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Form1.<GetPageLengthAsync>d__0>(ref awaiter, ref this);
                                flag = false;
                                return;
                            }
                        }
                        else
                        {
                            awaiter = this.<>u__$awaiter4;
                            this.<>u__$awaiter4 = new TaskAwaiter<string>();
                            this.<>1__state = -1;
                        }
                        string result = awaiter.GetResult();
                        awaiter = new TaskAwaiter<string>();
                        int length = result.Length;
                        this.<length>5__3 = length;
                        num = this.<length>5__3;
                    }
                    finally
                    {
                        if (flag && (this.<client>5__1 != null))
                        {
                            this.<client>5__1.Dispose();
                        }
                    }
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
            Label_0113:
                this.<>1__state = -2;
                this.<>t__builder.SetResult(num);
            }
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine param0)
            {
                this.<>t__builder.SetStateMachine(param0);
            }
        }
