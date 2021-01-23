    void Page_Load (object oSender, EventArgs oEventArgs)
    {
       if (IsPostBack == false)
       {
           oButton += new EventHandler(oButton_Click); // does not work
       }
       oButton += new EventHandler(oButton_Click); // does work
    }
