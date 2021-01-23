    public C<TResult> DoIt<TResult>()
    {
        C<TResult> a;
        a = new C<TResult>();
        a.Prop2; // <-- Can access
        return a;
    }
