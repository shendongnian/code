    while (this.Work)
        {
            _allDone.Reset();
            listener.BeginAccept(new AsyncCallback(AcceptCallBack), listener);
            _allDone.WaitOne();
        }
