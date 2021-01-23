     decimal sTotalReturn =0;     decimal sTotalReject =0;
                for (Int32 ii = 0; ii < lvRR.Items.Count;ii++ )
                {
    
                    Label lblTotalReturnQuantity = ((Label)lvRR.Items[ii].FindControl("lblTotalReturnQuantity"));
                    Label lblTotalRejectQuantity = ((Label)lvRR.Items[ii].FindControl("lblTotalRejectQuantity"));
                    Label lblDate = ((Label)lvRR.Items[ii] .FindControl("lblDate"));
                    Panel pnlDayTotal = ((Panel)lvRR.Items[ii].FindControl("pnlDayTotal"));
    
    
                    Literal ltrDayTotalReturn = ((Literal)lvRR.Items[ii].FindControl("ltrDayTotalReturn"));
                    Literal ltrDayTotalRejection = ((Literal)lvRR.Items[ii].FindControl("ltrDayTotalRejection"));
    
                    sTotalReturn = sTotalReturn + Convert.ToDecimal(lblTotalReturnQuantity.Text);
                    sTotalReject = sTotalReject + Convert.ToDecimal(lblTotalRejectQuantity.Text);
    
                    if (ii + 1 < lvRR.Items.Count)
                    {
                        Label lblDateNext = ((Label)lvRR.Items[ii + 1].FindControl("lblDate"));
    
                        if (lblDate.Text.ToString().Trim() != lblDateNext.Text.ToString().Trim())
                        {
                            pnlDayTotal.Visible = true;
                            ltrDayTotalReturn.Text = sTotalReturn.ToString();
                            ltrDayTotalRejection.Text = sTotalReject.ToString(); sTotalReturn = 0; sTotalReject = 0;
                        }
                    }
                    else
                    {
                        pnlDayTotal.Visible = true;
                        ltrDayTotalReturn.Text = sTotalReturn.ToString();
                        ltrDayTotalRejection.Text = sTotalReject.ToString();
                        sTotalReturn = 0; sTotalReject = 0;
                    }
    
                   
                }
