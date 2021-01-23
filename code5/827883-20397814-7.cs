    protected void Page_Load(object sender, EventArgs e)
    {
    	if (IsPostBack)
    	{
    		foreach (string key in Request.Form)
    		{
    			if (key.StartsWith("newTB"))
    			{
    				TextBox tb1 = new TextBox();
    				tb1.ID = key;
    				tb1.Text = Request.Form[key];
    				form1.Controls.Add(tb1);
    			}
    		}
    	}
    }
    
    protected void Page_Init(object sender, EventArgs e)
    {
    	Label label1 = new Label()
    		{
    			ID = "label1",
    			Text = "How many textboxes would you like to create?"
    		};
    
    	form1.Controls.Add(label1);
    
    	TextBox textBox1 = new TextBox()
    		{
    			ID = "TextBox1",
    			AutoPostBack = true,
    			CausesValidation = true
    		};
    
    	textBox1.TextChanged += new EventHandler(TextBox1_TextChanged);
    
    	form1.Controls.Add(textBox1);
    
    	RangeValidator rangeValidator = new RangeValidator()
    		{
    			ID="RangeValidator1",
    			ControlToValidate = "TextBox1",
    			MaximumValue = "5",
    			ErrorMessage = "Out of range!",
    			MinimumValue = "1"
    		};
    
    	form1.Controls.Add(rangeValidator);
    }
    
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
    	TextBox textBox = form1.FindControl("TextBox1") as TextBox;
    
    	if (Page.IsValid && textBox.Text != "")
    	{
    	    RemoveOldControls();
    
    	    for (int i = 0; i < Convert.ToInt16(textBox.Text); i++)
            {
                TextBox tb1 = new TextBox();
                tb1.ID = "newTB" + i.ToString();
                form1.Controls.Add(tb1);
            }
    	}
    }
    
    //Recursive method to remove all "newTB" textboxes
    private void RemoveOldControls()
    {
    	for (int i = 0; i < form1.Controls.Count; i++)
    	{
    		if (!string.IsNullOrEmpty(form1.Controls[i].ID) && form1.Controls[i].ID.StartsWith("newTB"))
    		{
    			TextBox newTextBox = form1.Controls[i] as TextBox;
    
    			if (newTextBox != null)
    				form1.Controls.Remove(newTextBox);
    			
    			RemoveOldControls();
    			break;
    		}
    	}
    }
