    [HttpGet]
    public List<SomeEntity> Get(){
            var gotResult = false;
            var result = new List<SomeEntity>();
            var tokenSource2 = new CancellationTokenSource();
            CancellationToken ct = tokenSource2.Token;
            Task.Factory.StartNew(() =>
            {
                // Do something with cancelation token to break current operation
                result = SomeWhere.GetSomethingReallySlow();
                gotResult = true;
            }, ct);
            while (!gotResult)
            {
                if (!Response.IsClientConnected)
                {
                    tokenSource2.Cancel();
                    return result;
                }
                Thread.Sleep(100);
            }
            return result;
    }
