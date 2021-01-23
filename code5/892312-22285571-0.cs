    protected void calInterestBtn_Click(object sender, EventArgs e)
            {
                double sum = 0.0;
                foreach (GridViewRow row in sTransactionEnquiryDB.Rows)
                {
                    Double d = Convert.ToDouble(row.Cells[14].Text);
                    sum += d;
                }
    
                calInterestTxt.Text = sum.ToString();
            }
