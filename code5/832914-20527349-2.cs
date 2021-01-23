    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        int rowCount = 0;
        //initialize a session.
        rowCount = Convert.ToInt32(Session["clicks"]);
        rowCount++;
        //In each button clic save the numbers into the session.
        Session["clicks"] = rowCount;
        BuildTextBoxes(rowCount, Convert.ToInt32(Session["clicks2"]));
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        int rowCount2 = 0;
        //initialize a session.
        rowCount2 = Convert.ToInt32(Session["clicks2"]);
        rowCount2++;
        //In each button clic save the numbers into the session.
        Session["clicks2"] = rowCount2;
         
        BuildTextBoxes(Convert.ToInt32(Session["clicks1"]), rowCount2));
    }
