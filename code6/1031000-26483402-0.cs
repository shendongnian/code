    protected void ValidateAndSave()
    {
        if (this.PerformValidations())
        {
            this.Save();
        }
    }
    private void buttonSave_Click(object sender, EventArgs e)
    {
        this.ValidateAndSave();
    }
    protected bool PerformValidations()
        /* could be virtual, if you want to do additional checks in derived classes */
    { ... }
    protected virtual void Save()
    { ... }
