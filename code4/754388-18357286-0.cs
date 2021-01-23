    protected override void OnBackKeyPress(CancelEventArgs e)
    {
        if (canvasIsDisplayed) // Replace by your own logic to detect if the canvas is opened
        {
            e.Cancel = true;
            // Hide the canvas
        }
    }
