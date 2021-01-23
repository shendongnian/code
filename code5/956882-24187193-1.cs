    void bigButton_MouseMove(object sender, MouseEventArgs e)
    {
        // This check relies on the MousePosition member of the form
        // You can avoid that by substracting e.Location by the bigButton's location
        if(!bigButton.ClientRectangle.Contains(bigButton.PointToClient(MousePosition)))
        {
            // Detach handler
            MouseMove -= Form1_MouseMove;
            // Show control again
            button1.Visible = true;
        }
    }
