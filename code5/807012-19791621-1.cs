    public static CancellationToken VerifyNotCancelled(this CancellationToken t) {
        t.ThrowIfCancellationRequested();
        return t;
    }
    ...
    Step1(token.VerifyNotCancelled());
    Step2(token.VerifyNotCancelled());
    Step3(token.VerifyNotCancelled());
