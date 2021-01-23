    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UpdateLabels();// code moved to a method
        }
    }
    protected void txtSubmit_Click(object sender, System.EventArgs e)
    {
    
      // at the end of your code 
      txtEventType.Text = string.Empty;
      txtEventName.Text = string.Empty;
      // set all the text boxes empty like above
      // update the label values 
      UpdateLabels();
    }
