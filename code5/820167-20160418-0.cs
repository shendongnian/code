    protected void lnkUp_Click(object sender, EventArgs e)
        {
            try
            {
                lblUp.Text = (int.Parse(lblUp.Text) + 1).ToString();
                lnkUp.Text = "Undo vote up";
    UpdatePanel1.update();
            }
            catch (Exception ex)
            {
                throw ex;
            }
    }
