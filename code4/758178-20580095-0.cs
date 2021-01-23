    foreach (GridViewRow gvp in gridView1.Rows)
        {
            System.Web.UI.HtmlControls.HtmlInputRadioButton rd = (System.Web.UI.HtmlControls.HtmlInputRadioButton)gvp.FindControl("rd");
            if (rd.Checked)
            {
                string s = rd.Value;
            }
            else
            {
            }
        }
