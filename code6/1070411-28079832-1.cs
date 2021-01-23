      GetControls help = new GetControls();
      private void btnpay_Click(object sender, EventArgs e)
        {
                  
          
            TenderUI usr = new TenderUI(prevUsr);
            usr.Back += usr_Back;
       
            help.Previous = pnlUI.Controls.OfType<Control>().ToArray(); 
       
            pnlUI.Controls.Clear();
            pnlUI.Controls.Add(usr);
           
            
        }
