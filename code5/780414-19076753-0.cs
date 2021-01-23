    protected void gv1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string alert = Request.QueryString["check"];
           
            if (e.Row.Cells[0].Text.ToString() == alert)
            {
                Session ["fn"] = e.Rows.Cells[2].Text;
                e.Rows.ForeColor = Color.Red;
        
            Response.Write(Session["fn"]);
            }
    }
