    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        int rowCount = Convert.ToInt32(Session["clicks"]) + 1;
        Session["clicks"] = rowCount;
        int rowCount2 = Convert.ToInt32(Session["clicks2"]) + 1;
        Session["clicks2"] = rowCount2;
        AddTextBoxes(rowCount, Panel1, myLabel1);
        AddTextBoxes(rowCount2, Panel2, myLabel2);
    }
    
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        int rowCount = Convert.ToInt32(Session["clicks"]) + 1;
        Session["clicks"] = rowCount;
        int rowCount2 = Convert.ToInt32(Session["clicks2"]) + 1;
        Session["clicks2"] = rowCount2;
        AddTextBoxes(rowCount, Panel1, myLabel1);
        AddTextBoxes(rowCount2, Panel2, myLabel2);
    }
    protected void AddTextBoxes(int numberToAdd, Panel panel, Label label)
    {
        //In each button clic save the numbers into the session.
        numberToAdd = rowCount;
        //Create the textboxes and labels each time the button is clicked.
        for (int i = 0; i < rowCount; i++)
        {
            TextBox TxtBoxU = new TextBox();
            TxtBoxU.ID = "TextBoxU" + i.ToString();
            //Add the labels and textboxes to the Panel.
            panel.Controls.Add(TxtBoxU);
        }
        label.Text = rowCount + "";
    }
