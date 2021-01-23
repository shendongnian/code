    int count = 1; //Could be anything
    
    for (int i = 0; i < count; i++ )
    {
        Label placeholder = new Label();
        StringBuilder sbExample = new StringBuilder();
        sbExample.Append("<div class='MiddleClass'></div>");
        HtmlString text = new HtmlString(sbExample.ToString());
        placeholder.Text = text.ToString();
        this.divMiddle.Controls.Add(placeholder);
    }
