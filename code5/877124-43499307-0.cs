            private void picMinimize_Click(object sender, EventArgs e)
            {
               try
               {
                   panelUC.Visible = false;                      //change visible status of your form, etc.
                   this.WindowState = FormWindowState.Minimized; //minimize
                   minimizedFlag = true;                         //set a global flag
               }
               catch (Exception)
               {
                
               }
            
            }
        private void mainForm_Resize(object sender, EventArgs e)
        {
                //check if form is minimized, and you know that this method is only called if and only if the form get a change in size, meaning somebody clicked in the taskbar on your application
            if (minimizedFlag == true)
            {
                
                panelUC.Visible = true;      //make your panel visible again! thats it
                minimizedFlag = false;       //set flag back
            }
        }
