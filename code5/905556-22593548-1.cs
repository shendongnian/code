    private List<string> TextBoxIdCollection
    {
        get
        {
            var collection = ViewState["TextBoxIdCollection"] as List<string>;
            return collection ?? new List<string>();
        }
        set { ViewState["TextBoxIdCollection"] = value; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (string textboxId in TextBoxIdCollection)
        {
            var textbox = new TextBox {ID = textboxId};
            TextBoxPlaceHolder.Controls.Add(textbox);
        }
    }
    
    protected void CounterTextBox_TextChanged(object sender, EventArgs e)
    {
        var collection = new List<string>();
        int total;
        if (Int32.TryParse(CounterTextBox.Text, out total))
        {
            for (int i = 1; i <= total; i++)
            {
                var textbox = new TextBox { ID = "QuestionTextBox" + i };
                // Collect this textbox id
                collection.Add(textbox.ID); 
                TextBoxPlaceHolder.Controls.Add(textbox);
            }
            TextBoxIdCollection= collection;
        }
    }
    
    protected void ConfirmButton_Click(object sender, EventArgs e)
    {
        foreach (Control ctr in TextBoxPlaceHolder.Controls)
        {
            if (ctr is TextBox)
            {
                string value = ((TextBox)ctr).Text;
                ResultLiteral.Text += value;
            }
        }
    }
