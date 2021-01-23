    ISubject<Tuple<string,int>> _subject = new Subject<Tuple<string,int>>();
    private int i;
    public void SendEvent(string message)
    {
        _subject.OnNext(Tuple.Create(message,i++));
    }
