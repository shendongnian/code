    protected void btnRun_Click(object sender, EventArgs e)
        {
            if (txtURL.Text.Length == 0) return;
            if (!(txtURL.Text.ToLower().StartsWith("http://") || txtURL.Text.ToLower().StartsWith("https://")))
                txtURL.Text = "http://" + txtURL.Text;
            try
            {
                Response.Redirect("Default.aspx?URL=(" + Encrypt(txtURL.Text, mainKey) + ")", false);
            }
            catch (Exception ex)
            {
                ShowPopUpMsg(ex.Message);
            }
