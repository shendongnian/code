    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
             HyperLink lnkbtn = (HyperLink)e.Row.FindControl("lb_certificate");
             int year = DateTime.Now.Year; //Or your Variable where year is stored.
             // If you are binding with Collection of Object, you can use this 
             //var data = (ObjectClass)e.Row.DataItem;
             //lnkbtn.NavigateUrl = "~/results/certificates/" + data.student_id + "/" + year + "/" + data.student_id  + "Cc.pdf";
             //If you are binding with DataTable
             var data = (DataRowView)e.Row.DataItem;
             lnkbtn.NavigateUrl = "~/results/certificates/" + data["student_id"] + "/" + year + "/" + data["student_id"] + "Cc.pdf";
        }
    }
