    private void btnGo_Click(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show("This will update your Website. " + 
           Environment.NewLine + "Are you Sure You want to update the Website?", 
           "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        if (result == DialogResult.Yes)
        {
             updateTimer.Start();
             Task.Factory.StartNew(() => ExecuteQuery());
        }
    }
    updateTimer_Tick()
    {
       updateTimer.Value +=1;
    }
