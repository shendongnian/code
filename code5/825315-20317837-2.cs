    public IObservable<List<Tweet>> GetTweetsObservable(this TwitterClient This)
    {
        var ret = new AsyncSubject<List<Tweet>>();
        try {
            This.GetTweetsWithCallback(tweets => {
                ret.OnNext(tweets);
                ret.OnCompleted();
            });
        } catch (Exception ex) {
            ret.OnError(ex);
        }
        return ret;
    }
