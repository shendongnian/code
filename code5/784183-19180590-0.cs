        private SqlParameter[] BuildParameters()
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@year", SqlDbType.Int) { Value = 2013 };
            return para;
        }
