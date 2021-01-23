    public event EventHandler RemoveAddress;
    protected void removeAddressUserControlButton_Click(object sender, EventArgs e)
    {
        // Find out if the event has been set, if so then call it
        if (this.RemoveAddress!= null)
        {
            RemoveAddress(sender, e);
        }
    }
