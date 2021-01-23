    private void BuildTextBoxes(int rowCount1, int rowCount2)
    {
        for (int i = 0; i < rowCount; i++)
        {
            TextBox TxtBoxU = new TextBox();
            TxtBoxU.ID = "TextBoxU" + i.ToString();
            //Add the labels and textboxes to the Panel.
            Panel1.Controls.Add(TxtBoxU);
        }
 
        myLabel1.Text = rowCount + "";
        for (int i = 0; i < rowCount2; i++)
        {
            TextBox TxtBoxU = new TextBox();
            TxtBoxU.ID = "TextBoxU" + i.ToString();
            //Add the labels and textboxes to the Panel.
            Panel2.Controls.Add(TxtBoxU);
        }
        myLabel2.Text = rowCount2 + "";
    }
