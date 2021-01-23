                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
		            myIfxCmd.Parameters.Clear();
                    myIfxCmd.Parameters.Add("p_year", IfxType.Integer, year);
                    myIfxCmd.Parameters.Add("p_month", IfxType.Integer, month);
                    myIfxCmd.Parameters.Add("p_calc_year", IfxType.Integer, calcYear);
