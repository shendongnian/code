    protected void LtModifiedDate_DataBinding(object sender, EventArgs e)
    {
        //Cast the sender to it's type
        Literal lit = (Literal)sender;
        
        //Convert the DateTime Text value to a DateTime
        DateTime dt = Convert.ToDateTime(lit.Text);
        
        if (dt == DateTime.MinValue)
        {
            //Cast the parent control (the div) to a HtmlGenericControl
            HtmlGenericControl div = (HtmlGenericControl)lit.Parent;
            
            //Set the visible property to false
            div.Visible = false;
        }
    }
