    protected void Page_Load(object sender, EventArgs e)
    {
         if(!Page.IsPostBack()) // we only want this stuff to happen on initial load        
         {
             hiddenField.value = 0; 
         }
    }
    protected void Enter9_OnClick(object sender, EventArgs e)
    {
        // a postback to the server just happened
        hiddenField.value = (double)hiddenField.value + 9;
    }
    ....
    ....
