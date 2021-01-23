    private void OpenForm()
    {
         var form2 = new Form2();
         form2.FormClosing += FormIsClosing;
         form2.Show();
    
         this.Hide();
    }
    
    private void FormIsClosing(object sender, FormClosingEventArgs e)
    {
         if (e.Cancel)
         {
             return;
         }
    
         this.Show();
         this.Update();
    }
