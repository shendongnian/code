    public void DTedit(object sender, EventArgs e)
    {
         //Place your code here
         DT_Navigator.btnCancel.Click -= new EventHandler(DTedit);  //This will remove handler from the button click and it will not be executed next time.
    }
    private void UserControl_Load(object sender, EventArgs e)
    {
        DT_Navigator.btnCancel.Click += new EventHandler(DTedit);
    }
