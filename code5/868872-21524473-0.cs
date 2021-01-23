    using (MySqlDataReader rdr3 = command3.ExecuteReader())
    {
        while (rdr3.Read())
        {
            if (count == 1)
            {
                AMT1 = Convert.ToDecimal(rdr3["paid_amount"].ToString());
                TOT1 = rdr3["paid_date"].ToString();
            }
            if (count == 2)
            {
                AMT2 = Convert.ToDecimal(rdr3["paid_amount"].ToString());
                TOT2 = rdr3["paid_date"].ToString();
            }
            if (count == 3)
            {
                AMT3 = Convert.ToDecimal(rdr3["paid_amount"].ToString());
                TOT3 = rdr3["paid_date"].ToString();
            }
            count++;
        }
    
        Response.Write("$AMT1=" + AMT1 + "|TOT1=" + TOT1 + "|AMT2=" + AMT2 + "|TOT2=" + TOT2 + "|AMT3=" + AMT3 + "|TOT3=" + TOT3 + "|TS=1#");
    }
