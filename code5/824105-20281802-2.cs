    struct Cplx
    {
        public readonly double Re;
        public readonly double Im;
        public string Geo
        {
            get
            {
                return "(" + Re + "," + Im + ")";
            }
        }
        public Cplx(double re, double im)
        {
            Re = re;
            Im = im;
        }
        public Cplx(string cplx)
        {
            var input = cplx.Split(new[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Re = Convert.ToDouble(input[0]);
            Im = Convert.ToDouble(input[1]);
        }
    }
