	public bool GetCompleteOuder(out TOUD user, string p)
	{
		user = new TOUD();
	
		try
		{
			db.TOUDS.SingleOrDefault(t => t.Voornaam == p);
			return true;
		}
		catch
		{
			return false;
		}
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		string naam = User.Identity.Name;
		TOUD user;
		if(GetCompleteOuder(out user, naam))
		{
			NaamTxt.Text = user.<fieldname>;
		}
		else
		{
			NaamTxt.Text = string.empty;
		}
	}
