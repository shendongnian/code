    protected void grdTaskDataCat1_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
    TextBox txt = (TextBox)e.Row.FindControl("txtTaskName");
                   
                    if (txt.Text != "")
                    {
                        txt.Attributes.Add("readonly", "readonly");
                       
                    }
    }
    }
