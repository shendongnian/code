    private int HowManyControls {
        get 
        {
            if (Session["HowManyControls"] == null) return 0;
            else return (int)Session["HowManyControls"];
        }
        set
        {
            Session["HowManyControls"] = value;
        }   
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Page.Ispostback && HowManyControls > 0)
        {
            //generate the controls dynamically
            GenerateControls(HowManyControls);  
        }
    }
    protected void btnBookQty_Click(object sender, EventArgs e)
    {
        //get the number of controls to generate dynamically from the user posted values
        HowManyControls = Convert.ToInt32(TextBox1.Text);
        //generate the controls dynamically
        GenerateControls(HowManyControls);  
    }
    
    protected void btnSaveToDatabase_Click(object sender, EventArgs e)
    {
        //iterate on the control's collection in pnlBook object.
        for (int i = 1; i <= HowManyControls; i++)
        {
            //save those value to database accessing to the control's properties as you'd regularly do: 
            TextBox tb = (TextBox)pnlBooks.FindControl("TextBoxTitle" + i.ToString());
            TextBox tb2 = (TextBox)pnlBooks.FindControl("TextBoxAuthor" + i.ToString();
            
            //store these values:
            tb.Text;
            tb2.Text;
        }
    }
    
    private void GenerateControls(int count)
    {
        if (count == 0) { return; }
        
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
    }
