        MyThread = new Thread(delegate() 
        { 
             try
               {
               Notify.UserInput(this,ref MainForm.NumberOFWindows);
               }
               catch (Exception ex)
               {
                MessageBox.Show(ex.Message);
               }
        });
