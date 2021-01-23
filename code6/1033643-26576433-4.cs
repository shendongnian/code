    class Result
    {
        public int kk { get; set; }
        public int m { get; set; }
    }
    static Result AddMult(int ii, int jj)
    {
        int kk, m;
        kk= ii+jj;
        m=ii*jj;
        return new Result { kk = kk, m = m };
    } 
