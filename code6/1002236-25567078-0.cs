    protected void myButton_Click(object sender, EventArgs e)
    {
        if (SomethingHappened!= null)
        {
            this.SomethingHappened(this, EventArgs.Empty);
        }
    }
