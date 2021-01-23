    protected void MyUpdButton_Click(object sender, EventArgs e)
    {
        var MyDateInsCalendar = GridView1.Rows[GridView1.EditIndex].FindControl("MyDateInsCalendar") as Calendar;
        MyDateInsCalendar.Visible = false;
    }
