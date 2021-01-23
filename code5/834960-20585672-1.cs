    protected override void OnFormClosing(FormClosingEventArgs e)
    {
       
    
       DialogResult dgResult = MessageBox.Show(this, "Are you sure you want to exit?", "", MessageBoxButtons.YesNo); 
        if(dgResult==DialogResult.No)
                e.Cancel = true;
            
          else
         //here  you can use 
             Application.Exit();
            //or  you can use which is not recomended
               // Environment.Exit()     
    }
