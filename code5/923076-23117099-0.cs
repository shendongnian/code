       protected void gvTest_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var cbListSource = getDataSource(); // get the data source values for the checkboxlist to bind to
                CheckBoxList cblItems = (CheckBoxList)e.Row.FindControl("cblItems");
                cblItems.DataSource = cbListSource;
                cblItems.DataTextField = "QuestionName";
                cblItems.DataValueField = "QuestionId";
                cblItems.DataBind();
                cblItems.Attributes.Add("onclick", "alert('Your alert text goes in here')");
            }
        }
