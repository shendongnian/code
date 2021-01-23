    private void createButton_Click(object sender, EventArgs e)
    {
         bool gotIssues = this.ValidateChildren();
         if (gotIssues) 
         {
             // someone didn't validate well...
         }
    }
