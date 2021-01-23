    public void Page_Init(object sender, EventArgs e)
    {
        CreateDynamicControls();
    }
    private void CreateDynamicControls()
    {
        notifications = (List<TextBox>)(Session["Notifications"]);
        if (notifications != null)
        {
            foreach (TextBox textBox in notifications)
            {
                NotificationArea.Controls.Add(textBox);
            }
        }
    }
