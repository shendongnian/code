    class MyCodeBehindClass
    {
        private List<string> _StakeDesc;//use a dynamically sized array
        private List<string> StakeDesc
        {
            get
            {
                if (Session[StakeDescKey] != null)
                    _StakeDesc = (List<string>)Session[StakeDescKey];
                else
                {
                    _StakeDesc = GetStakeDesc();
                }
                return _StakeDesc;
            }
            set { _StakeDesc = value; }
        }
    
        private List<string> GetStakeDesc()
        {
            using ([SQL Data Connection])
            {
                var stakes = from st in ddl.STK_Stakes
                             where st.STK_EVT_FK == eventId
                             select new
                                 {
                                     st.STK_Description
                                 };
    
                Session[StakeDescKey] = stakes.ToList();//Populate cache
            }
        }
    
        private void PageLoad()
        {
            //if not postback...
            foundDDL.DataSource = StakeDesc;//Smart property that checks cache
            foundDDL.DataBind();
        }
    }
