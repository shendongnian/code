    // use like
    string desc = MyEnumLike.P.Desc;
    public sealed class MyEnumLike
    {
        public static readonly MyEnumLike P = new MyEnumLike("aco", 1000, 4, 8);
        public static readonly MyEnumLike L = new MyEnumLike("acs", 2100, 1, 9);
        public static readonly MyEnumLike S = new MyEnumLike("acn", 3500, 1, 6);
        public static readonly MyEnumLike H = new MyEnumLike("ach", 5400, 1, 6);
        public string Desc { get; set; }
        
        int bt;
        int Qp;
        int lp;
    
        private MyEnumLike(String desc, int bt, int Qp, int lp) {
            this.Desc = desc;
            this.bt = bt;
            this.Qp = Qp;
            this.lp = lp;
        }
    }
