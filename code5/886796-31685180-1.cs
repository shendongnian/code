    // UC - callback from within the usercontrol
    protected void UserControlButton_Click(object sender, EventArgs e)
    {
       if (IsPostback)
       {
          // do some processing
          if (this.OnCallbackAction != null)
          {
             this.OnCallbackAction.Invoke(this, new CustomEventArgs("ET phone home") );
          }
       }
    
    }
