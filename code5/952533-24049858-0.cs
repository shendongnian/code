    yourControl.KeyPress += passwordString_KeyPress; // in Form load 
    private void yourControl_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)(Keys.Enter))
        {
            // your code here when the Enter key is pressed
        }
    }
