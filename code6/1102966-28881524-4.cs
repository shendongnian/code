    object lockObject=new object();
    BigInteger result=BigInteger.Zero;
    Parallel.For(0,16,() => BigInteger.Zero,(i,pls,subResult) => {
        return subResult+GetBigInteger(i);
    },subResult => {
        lock(lockObject) {
            result+=subResult;
        }
    });
