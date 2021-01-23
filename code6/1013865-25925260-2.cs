    var do= new Do();
    
    var result = await do.Later(() => 1 + 2);
    public class Do
    {
        private Subject<Action> _backlog = new Subject<Action>();
        public Do()
        {
             Observable.CombineLatest(_backlog, Observable.Timer(...), (l, r) => l)
                  .Subscribe(x => x());
        }
        public Task<T> Later(Func<T> getResult)
        {
            var tcs = new TaskCompletionSource<T>();
            _backlog.OnNext(() => {
                 try
                 {
                     var result = getResult();
                     tcs.SetResult(result);
                 }
                 catch(Exception ex)
                 {
                     tcs.SetException(ex);
                 }
            });
            return tcs.Task;
        }
    }
