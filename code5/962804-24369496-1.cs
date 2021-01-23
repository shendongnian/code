    public DataSet newleger(string accno, string fromdate, string todate)
	{
	    SqlConnection con = new SqlConnection(@"Data Source=123-PC;Initial Catalog=bcounts;Persist Security Info=True;User ID=Saba;Password=123");
	    con.Open();
	    SqlCommand cmd = new SqlCommand("select gt.Value_Date,gt.Voucher_no+'-'+gr.VchrType as voucher,gt.Acct_Nirration,gr.InstrumentNo,gt.Dr_Amount,gt.Cr_Amount  from gl_transaction gt, Gl_Ref gr where gt.Accountno = '" + accno + "'  and gt.Voucher_No=gr.Voucher_no  and gt.Value_Date between '" + fromdate + "' and '" + todate + "'", con);
	    SqlDataAdapter adp = new SqlDataAdapter();
		adp.SelectCommand = cmd;
		
	    decimal crsum = 0;
	    decimal drsum = 0;
	    decimal balance = 0;
	    DataSet ds = new DataSet("Ledger");;
	    adp.Fill(ds);
		
		foreach (DataRow dr in ds.Tables[0].Rows)
		{
			//do stuff here....
			if(Convert.ToDecimal(dr[4]) > 0)
			{
				balance = balance + Convert.ToDecimal(dr[4]);
	            drsum += Convert.ToDecimal(dr[4]);
			}
			else
			{
				 balance = balance - Convert.ToDecimal(dr[5]);
	             crsum += Convert.ToDecimal(dr[5]);
			}
		}
		
		//add the totals
		DataRow dd = ds.Tables[0].NewRow();
        //dd[0] = "-";
        //dd[1] = "-";
        //dd[2] = "-";
        //dd[3] = "-";
        dd[4] = drsum;
        dd[5] = crsum;
        //data.Add(new datalist7("-", "-", "-", "-", drsum.ToString(), crsum.ToString(), "-"));
		
	   
	    return ds;
	}
