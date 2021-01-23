    class Program
    {
        static void Main(string[] args)
        {
             Task t1 = new Task();
             Task t2 = new Task();
             t1.store("task1","gui design",new DateTime(2014, 01, 01),new DateTime(2014 ,04 ,04),"completed");
        }
    }
    class Task
    {
        string _Tid;
        string _tn;
        DateTime _sdate;
        DateTime _edate;
        string _status;
        public void store(string tid, string tname, DateTime start, DateTime end, string sts)
        {
            this._Tid = tid;
            this._tn = tname;
            this._sdate = start;
            this._edate = end;
            this._status = sts;
        }
        public void print()
        {
            Console.WriteLine("\n {0}\t{1}\t{2}\t{3}\t{4}", this._Tid, this._tn, this._sdate, this._edate, this._status);
        }
    }
