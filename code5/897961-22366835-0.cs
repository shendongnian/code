    private void select1_Click(object sender, EventArgs e)
    {
        if (select1Down == false)
        {
            // ... stuff
            this.BeginInvoke(
            () => {
                select1.Enabled = false;
                select2.Enabled = false;
                select1Down = true;
            });
        }
    }
