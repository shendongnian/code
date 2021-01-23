    int intIncrementValue = 20;
 
    private void chkAlpha_Click(object sender, EventArgs e)
    {
       if (chkAlpha.Checked)
       {
         if(pbWaitMessage.Value + intIncrementValue <= pbWaitMessage.Maximum)
            pbWaitMessage.Value = pbWaitMessage.Value + intIncrementValue ;
       }
       else
       {
         if(pbWaitMessage.Value - intIncrementValue >= pbWaitMessage.Minimum)
            pbWaitMessage.Value = pbWaitMessage.Value - intIncrementValue ;
       }
    }
