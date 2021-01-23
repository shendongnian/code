    protected void btnGo_Click(object sender, EventArgs e)
        {
            GridView1.PageIndex = Convert.ToInt16(txtGoToPage.Text);
            txtGoToPage.Text = "";
            GridView1.DataBind()
        }
