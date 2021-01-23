	protected void Page_Init(object sender, EventArgs e)
    {
        //Init used because TestPanel doesn't exist yet
        CreateTestButton();
    }
    private void CreateTestButton()
    {
        var lb = new LinkButton();
        lb.Text = "hello";
        lb.Command += lb_Command;
        TestPanel.Controls.Add(lb);
    }
    void lb_Command(object sender, CommandEventArgs e)
    {
        throw new NotImplementedException();
    }
