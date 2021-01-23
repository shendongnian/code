    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        AddTextBoxes(Session["clicks"], Panel1, myLabel1);
        AddTextBoxes(Session["clicks2"], Panel2, myLabel2);
    }
    
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        AddTextBoxes(Session["clicks"], Panel1, myLabel1);
        AddTextBoxes(Session["clicks2"], Panel2, myLabel2);
    }
    protected void AddTextBoxes(int numberToAdd, Panel panel, Label label)
    {    
        int rowCount = 0;
        //initialize a session.
        rowCount = Convert.ToInt32(numberToAdd);
        rowCount++;
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
