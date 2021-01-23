    protected override void OnBackKeyPress(CancelEventArgs e)
    {
        if (this.History.Count > 0)
        {
            e.Cancel = true;
            var picture = this.History.Pop();
            // Display the picture
        }
    }
