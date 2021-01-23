    private void LoadTextBoxes()
    {
        if(ViewState["lstTBs"] == null)
        {
        }
    }
    List<TextBox> lstTBs ;
       for (int i = 1; i <= count; i++)
        {
            TextBox tb = new TextBox();
            TextBox tb2 = new TextBox();
            tb.Text = "Book  " + i.ToString() + " Title";
            tb2.Text = "Book  " + i.ToString() + " Author";
            tb.ID = "TextBoxTitle" + i.ToString();
            tb2.ID = "TextBoxAuthor" + i.ToString();
            pnlBooks.Controls.Add(tb);
            pnlBooks.Controls.Add(tb2);
            pnlBooks.Controls.Add(new LiteralControl("<br />"));
    
        } 
