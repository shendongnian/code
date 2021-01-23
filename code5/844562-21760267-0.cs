    String calltipText = null; //start out with null calltip
    ...
    private void Editor_TextChanged(object sender, EventArgs e)
    {
        if (calltipText != null)
        {
             CallTip.Show(calltipText); //note, you may want to assign a position
             calltipText = null; //reset string
        }
        ... 
    }
    ...
    private void Editor_AutoCompleteAccepted(object sender, AutoCompleteAcceptedEventArgs e)
    {
        if (e.Text == "someThing")
        {
             /* Code to add text to control */
             ... 
             calltipText = "someKindOFText"; //assign value to calltipText
        }
    }
