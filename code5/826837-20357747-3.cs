	protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            string _evt = this.Request["__EVENTTARGET"]; // 1st parameter
            string _eva = this.Request["__EVENTARGUMENT"]; // 2nd parameter
            switch (_evt)
            {
                case "fileUpload":
                    btnReportImage_Click(); 
                    break;
                default:
                    break;
            }
        }
    }
	
	protected void btnReportImage_Click() // remove sender & event arguments here, you do not need them
	{
		//your code
	}
	 
	 
	
