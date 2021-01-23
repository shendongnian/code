    public override void Set(string name, string value)
    {
    	if (Logging.On)
    	{
    		Logging.PrintInfo(Logging.Web, this, "Set", name.ToString() + "=" + value.ToString());
    	}
    	if (name == null)
    	{
    		throw new ArgumentNullException("name");
    	}
    	if (value == null)
    	{
    		throw new ArgumentNullException("value");
    	}
    	if (name == string.Empty)
    	{
    		throw new ArgumentException(SR.GetString("net_emptystringcall", new object[] { "name" }), "name");
    	}
    	if (value == string.Empty)
    	{
    		throw new ArgumentException(SR.GetString("net_emptystringcall", new object[] { "value" }), "name");
    	}
    	if (!MimeBasePart.IsAscii(name, false))
    	{
    		throw new FormatException(SR.GetString("InvalidHeaderName"));
    	}
    	if (!MimeBasePart.IsAnsi(value, false))
    	{
    		throw new FormatException(SR.GetString("InvalidHeaderValue"));
    	}
    	name = MailHeaderInfo.NormalizeCase(name);
    	MailHeaderID iD = MailHeaderInfo.GetID(name);
    	if ((iD == MailHeaderID.ContentType) && (this.part != null))
    	{
    		this.part.ContentType.Set(value.ToLower(CultureInfo.InvariantCulture), this);
    	}
    	else if ((iD == MailHeaderID.ContentDisposition) && (this.part is MimePart))
    	{
    		((MimePart) this.part).ContentDisposition.Set(value.ToLower(CultureInfo.InvariantCulture), this);
    	}
    	else
    	{
    		base.Set(name, value);
    	}
    }
