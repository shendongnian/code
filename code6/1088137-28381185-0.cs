    if (row.RowType == DataControlRowType.DataRow)
    {
    
                    Label lblReqNo = (Label)row.FindControl("lblReqNo1");
                    Label lblFranchise_id = (Label)row.FindControl("lblFranchise_id");
                    objFund.Transfer_id = int.Parse(lblReqNo.Text);
                    objFund.Type = 9;
                    int a = objFund.Insert();
                    objFund.Transfer_id = int.Parse(lblFranchise_id.Text);//franchise Id
                    objFund.CreditAmt = float.Parse(lblReqNo.Text);
                    objFund.Type = 5;
                    int b = objFund.Insert();
                    if (b > 0)
                    {
                        msg.Alert("Request accepted and mount Debited ");
                    }
    }
