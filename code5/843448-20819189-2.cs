    public void Form1_Load(object sender, EventArgs e)
    {
        if(Properties.Settings.Default["FirstRun"] == true) 
        {
           //First application run
           //Update setting
           Properties.Settings.Default["FirstRun"] = false;
           //Save setting
           Properties.Settings.Default.Save();
           //Create new instance of Dialog you want to show
           FirstDialogForm fdf = new FirstDialogForm();
           //Show the dialog
           fd.ShowDialog();
        }
        else
        {
           //Not first time of running application.
        }
    }
