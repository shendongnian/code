    private void ComputeBySalesSalesID(DataSet ds)
    {
             if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow drSum = ds.Tables[0].Rows[0];
                        GridViewRow footer = dgOpenBal.FooterRow;
                        var lblTotal = (Label)footer.FindControl("lblTotal");
                        lblTotal.Text = drSum["sum"].ToString();
                    }
    }
