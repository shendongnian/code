    [CompilerGenerated]
    private sealed class <CalleeAsync>d__2
    {
        private int <>1__state;
        private bool $__disposing;
        public System.Runtime.CompilerServices.AsyncTaskMethodBuilder<int> $builder;
        public Action <>t__MoveNextDelegate;
        public Program <>4__this;
        private TaskAwaiter<int> <a1>t__$await4;
        public void MoveNext()
        {
            int result2;
            System.Runtime.CompilerServices.AsyncTaskMethodBuilder<int> asyncTaskMethodBuilder;
            try
            {
                int num = this.<>1__state;
                if (num != 1)
                {
                    if (this.<>1__state == -1)
                    {
                        return;
                    }
                    this.<a1>t__$await4 = this.<>4__this.SomeOperationAsync().GetAwaiter<int>();
                    if (!this.<a1>t__$await4.IsCompleted)
                    {
                        this.<>1__state = 1;
                        this.<a1>t__$await4.OnCompleted(this.<>t__MoveNextDelegate);
                        return;
                    }
                }
                else
                {
                    this.<>1__state = 0;
                }
                int result = this.<a1>t__$await4.GetResult();
                this.<a1>t__$await4 = default(TaskAwaiter<int>);
                result2 = result;
            }
            catch (Exception exception)
            {
                this.<>1__state = -1;
                asyncTaskMethodBuilder = this.$builder;
                asyncTaskMethodBuilder.SetException(exception);
                return;
            }
            this.<>1__state = -1;
            asyncTaskMethodBuilder = this.$builder;
            asyncTaskMethodBuilder.SetResult(result2);
        }
        [DebuggerHidden]
        public void Dispose()
        {
            this.$__disposing = true;
            this.MoveNext();
            this.<>1__state = -1;
        }
        [DebuggerHidden]
        public <CalleeAsync>d__2(int <>1__state)
        {
            this.<>1__state = <>1__state;
        }
    }
