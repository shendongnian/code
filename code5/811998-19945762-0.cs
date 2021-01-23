    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // You can replace this with a switch statement
                if (DataBinder.Eval(e.Row.DataItem, "Discontinued").ToString() == "False")
                {
                    TextBox txtTemp = new TextBox();
                    txtTemp.Text = "I am a textbox";
                    e.Row.Cells[10].Controls.Add(txtTemp);
                }
                else
                {
                    // Add other controls here
                }
            }
        }
