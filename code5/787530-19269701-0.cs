    protected void insturenButton_Click(object sender, EventArgs e)
    {
      string htmlString = Questions();   // call your function which returns the string.
      buttonContainer.InnerHtml = htmlString;
    }
    
