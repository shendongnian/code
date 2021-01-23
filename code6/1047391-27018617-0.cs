    i did it, just write these lines in default.cs
    protected void btn_Click(object sender, EventArgs e)
        {
            TextBox myLabel = (TextBox)CalendarUserControl1.FindControl("txtData");
            string x = myLabel.Text.ToString();
            Calendar c = (Calendar)CalendarUserControl1.FindControl("Calendar1");
            string date = c.SelectedDate.ToString();
            DropDownList b = (DropDownList)CalendarUserControl1.FindControl("ddlthings");
            string ddl = b.SelectedValue;
            Label1.Text = "Your text is: " + x + "<br />"+ " Your Selected Date is: " + date + "<br />"+ " Your Selected Item is: " + ddl;
        }
