        //Create a private variable.
		private string CartValue;
		
		protected void Page_Load(object sender, EventArgs e)
        {
            //Check your session variable "will be empty if the session variable is null".
            CartValue = Session["CartValue"] != null && !string.IsNullOrEmpty(Session["CartValue"].ToString()) ? Session["CartValue"].ToString() : "";
            if (!IsPostBack)
            {
                //Your code...
            }
        }
