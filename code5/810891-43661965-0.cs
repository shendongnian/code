    private const int waittime = 2;
    private DateTime clickTime = DateTime.Now;
    private void cmd_TimeStamp_Click(object sender, EventArgs e)
    {
      if ((DateTime.Now - clickTime).Seconds < waittime)
        return;
      else
        clickTime = DateTime.Now;
      try
      {
        cmd_TimeStamp.Enabled = false;
        //Do some stuff in here
      }
      catch (Exception ex)
      {
        //Show error if any
        MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally
      {
        cmd_TimeStamp.Enabled = true;
      }
    }
