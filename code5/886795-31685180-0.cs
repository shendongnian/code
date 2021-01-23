     // UC - setting up delegate and usercontrol property to store it
     public delegate void CallbackAction(object sender, CustomEventArgs e);
     public CallbackAction OnCallbackAction
     {
        get { return Session["CallbackAction"] as CallbackAction;  }
        set { Session["CallbackAction"] = value; }
     }
