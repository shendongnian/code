    protected void btnGo_Click(object sender, EventArgs e)
        {
            GridView1.PageIndex = Convert.ToInt16(txtGoToPage.Text) -1; //since PageIndex starts from 0 by default.
            txtGoToPage.Text = "";
            GridView1.DataBind()
        }
