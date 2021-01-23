    // Main Page - load event 
    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostback)
       {
          // register with usercontrol
          this.UserControlFoo.OnCallbackAction += CallbackFromUserControl_Click;
       }
    }
    
    // Main Page - this event will get called back when ET phones home
    protected void CallbackFromUserControl_Click(object sender, CustomEventArgs e)
    {
       // phoned home from usercontrol
    }
