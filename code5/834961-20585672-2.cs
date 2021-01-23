    protected override void OnFormClosing(FormClosingEventArgs e)
    {
       
    
       DialogResult dgResult = MessageBox.Show(this, "Are you sure you want to exit?", "", MessageBoxButtons.YesNo); 
        if(dgResult==DialogResult.No)
                e.Cancel = true;
            
          else
         //here  you can use  Environment.Exit  which is not recomended because it does not generate a message loop to notify others form
          Environment.Exit(1);  
            //or  you can use
             //Application.Exit();  
    }
