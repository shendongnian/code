    // UserControl1 code
    public event EventHandler SomethingHappened;
    private void Button1_Click(object sender, EventArgs e)
    {
        if (SomethingHappened != null) // notify listeners, if any
           SomethingHappened(this, EventArgs.Empty);
    }
