    EnableControls()
    {
       for(int i=1; i<6;i++)
       {
          string controlName = "ctl" + i;
          this.Controls[controlName].Enabled = true;
       }
    }
  
