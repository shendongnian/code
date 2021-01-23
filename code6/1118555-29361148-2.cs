    string name = GridView1.SelectedRow.Cells[2].Text + ' ' + GridView1.SelectedRow.Cells[3].Text;
    Session.Add("First_Name", name);
    string pageName = Session["First_Name"].ToString();
        if(pageName.ToUpper()=="GENERAL_BILL.ASPX")
          Response.Redirect("General_Bill.aspx?First_Name=" + this.lblname.Text);
        else
          Response.Redirect("Add_admission_record.aspx?First_Name=" + this.lblindex.Text);
