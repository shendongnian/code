    class ViewSaleInfo
    {
        ViewSaleInfo(DataRow t1, DataRow t2)
        {
            this.t1 = t1;
            this.t2 = t2;
        }
        public String COL_A
        {
            get
            {
                return t1["COL A"];
            }
            set
            {
                t1["COL A"] = val;
            }
        }
        // and other properties required for view from both data tables
    }
