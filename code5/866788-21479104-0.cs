    protected void btn_Clicked(object sender, EventArgs e)
    {
       
        Button Sample = sender as Button;
        GridViewRow row = Sample.NamingContainer as GridViewRow;
        DropDownList drp = row.FindControl("TitleList") as DropDownList;
        //Now use drp.SelectedValue
        }
    }
