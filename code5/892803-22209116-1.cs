    private void btnOne(object sender, EventArgs e) //Do this for each button
    { 
        ChangeVisualState(sender as Button, false);
        //Statements
        ChangeVisualState(sender as Button, true);
    }
    public void ChangeVisualState(Button btn, bool buttonState)
    {
        btn.Enabled = buttonState;
        progressBar.Visible = !buttonState;
    }
