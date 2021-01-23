    struct CalifornicatedNumber
    {
        private string value;
        public CalifornicatedNumber(string value) 
        { 
           this.value = value; 
        }
        static public implicit operator CalifornicatedNumber(string value)
        {
           return new CalifornicatedNumber(value);
        }
        static public implicit operator CalifornicatedNumber(double value)
        {
            return new CalifornicatedNumber(value.ToString());
        }
        static public implicit operator double(CalifornicatedNumber calif)
        {
            return double.Parse(MakeItMakeSense(calif.value));
        }
        static private string MakeItMakeSense(string calif)
        {
             if (calif.Count(x => x == '.') > 1)
             {
                if ((calif.Count(x => x == '.') == 2) && (calif.Last() == '.')){
                    calif = calif.Substring(0, calif.Length - 1); }
                 else {
                    calif = calif.Substring(0,
                            calif.IndexOf('.', calif.IndexOf('.') + 1)); }
             }
             return calif;
        } 
    }
