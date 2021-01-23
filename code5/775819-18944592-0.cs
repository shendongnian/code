    protectec void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            //Not a postBack: Normal page load
            //Init your page here
        }
        else
        {
            //It's a PostBack (from a command).
            //Do nothing or init stuff your all your commands.
        }
    }
