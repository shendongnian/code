     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
             CheckBox newcheck = new CheckBox();
                newcheck.ID = "CheckBox" + i;
                newcheck.AutoPostBack = true;
                newcheck.CausesValidation = false;
                newcheck.CheckedChanged += new EventHandler(newcheck_CheckedChanged);
            }
         }
