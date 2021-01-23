    Public void Page_Init(Object Sender, EventArgs e)
    {
       if(Session["MyControlFlag"]!=null && (bool)Session["MyControlFlag"])
          AddMyControl();
    }
