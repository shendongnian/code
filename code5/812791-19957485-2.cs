    protected void Page_Load(object sender, EventArgs e)
    {
    	if (this.IsPostBack)
    		return;
    
    	RecaptchaControl rc = new RecaptchaControl { PublicKey = "6LcvP...", PrivateKey = "6LcvP..." };
    	this.Controls.Add(rc);
    }
