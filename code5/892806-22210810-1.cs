    private void PerformTasks(object obj)
    {
        //The passed in obj is the sender, in our case the clicked button
        Button btn = obj as Button;
        ButtonDelegate delButton = new ButtonDelegate(isEnabled);
        ProgressBarDelegate delProgressBar = new ProgressBarDelegate(isVisible);
        //Make a thread safe call to disable button and make progressbar visible
        if (this.InvokeRequired)
        {
            btn.Invoke(delButton, btn, false);
            progressBar1.Invoke(delProgressBar, true);
        }
        else
        {
            btn.Enabled = false;
            progressBar1.Visible = true;
        }
        switch (btn.Name)
        {
            case "button1":
                //Code to run in background for button 2
                //alternatively, for organization/debuging purposes
                //create a sub method
                Thread.Sleep(6000);
                break;
            case "button2":
                //case 2
                break;
            //... more cases
        }
        //Make a thread safe call to re-enable button and make progressbar invisible
        if (this.InvokeRequired)
        {
            btn.Invoke(delButton, btn, true);
            progressBar1.Invoke(delProgressBar, false);
        }
        else
        {
            btn.Enabled = true;
            progressBar1.Visible = false;
        }
        
    }
