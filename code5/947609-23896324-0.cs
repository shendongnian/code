    this.FormClosing += MainPage_FormClosing; // occurs before closing of the form
    this.FormClosed += MainPage_FormClosed; // occurs after the closing of the form
    private void MainPage_FormClosed(object sender, FormClosedEventArgs e)
    {
        // your code here to do something before closing the form
    }
    private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
    {
        // your code here to do something after the form is closed
    }
