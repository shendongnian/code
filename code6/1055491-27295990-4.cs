    //Constructor
    public Main_GUI()
    {
        InitializeComponent(); //a form with a button named BUTTON_Start, and a label named LABEL_log
        p =  new Processes();
        
        // Subscribe to the event.
        p.Finished += p_Finished;         
    }
    
    // This will get called when the Finished event is raised.
    private void p_Finished(object sender, EventArgs e)
    {
       LABEL_log.Text = "Finished!";
    }
