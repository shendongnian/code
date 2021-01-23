    private void timer2_Tick(object sender, EventArgs e)
    {
        if( this.DesignMode ) return; 
        try
        {
            if ( !CheckLock())
            {
                MessageBox.Show("No lock found.");
                this.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("No lock found.");
            this.Close();
        }
    }
