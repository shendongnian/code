    svnPathCheck_lbl.Visible = true; //Show the label     
    Task connectToSVN = new Task(() => { this.connectToSVN; }); connectToSVN.Start(); //Open new Task to complite the code without blocking the GUI.
        
    private void connectToSVN 
    {
        // Check validity of SVN Path
        string svnValidity = getCMDOutput("svn info " + SVNPath_txtbox.Text);
        // Here we call Regex.Match. If there is a 'Revision:' string, it was successful
        Match match = Regex.Match(svnValidity, @"Revision:\s+([0-9]+)", RegexOptions.IgnoreCase);
        this.Dispatcher.Invoke((Action)(() =>
        {
           svnPathCheck_lbl.Visible = false; //Hide the label
        }
        ));
    }
