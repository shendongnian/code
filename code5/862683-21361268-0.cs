    protected void rbBatch_CheckedChanged(object sender, EventArgs e)
    {
      handle();
    }
    
    protected void rbEmployee_CheckedChanged(object sender, EventArgs e)
    {
      handle();
    }
    
    private void handle()
    {
       if(rbBatch.Checked)
       {
         gvBatch.visible=true;
         gvMain.visible=false;
       }
       else if(rbEmployee.Checked)
       {
         gvBatch.visible=false;
         gvMain.visible=true;
       }
    }
