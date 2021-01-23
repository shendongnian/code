    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);
    
        if (e.CloseReason == CloseReason.WindowsShutDown) return;
    
        switch (MessageBox.Show(this, "Are you sure you want to exit?", "", MessageBoxButtons.YesNo))
        {
            case DialogResult.No:
                e.Cancel = true;
                break;  
             
          case   DialogResult.Yes:
          
            default:
         //here  you can use 
             Application.Exit();
            //or  you can use which is not recomended
               // Environment.Exit() 
          break;
  
        }
    }
