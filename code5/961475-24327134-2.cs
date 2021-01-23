    private SqlConnection con { get; set; }
    public void SetConnection(string server, string database, string username, string password)
    {
        con = new SqlConnection(String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", server, database, username, password));
    }
    public DataSet getleger(string accno, string fromdate, string todate)
    {
        try
        {
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "select Convert(nvarchar(10),gt.Value_Date,111) as [Value_Date],gt.Voucher_no+'-'+gr.VchrType as voucher,gt.Acct_Nirration,gr.InstrumentNo,gt.Dr_Amount,gt.Cr_Amount  from gl_transaction gt, Gl_Ref gr where gt.Accountno = @accno and gt.Voucher_No=gr.Voucher_no  and gt.Value_Date between @fromdate and @todate";
                    cmd.Parameters.AddWithValue("@accno", accno);
                    cmd.Parameters.AddWithValue("@fromdate", fromdate);
                    cmd.Parameters.AddWithValue("@todate", todate);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            da.Fill(ds);
                            return ds;
                        }
                    }
                }
            }
        }
        catch (SqlException se)
        {
            //handle error
        }
    }
