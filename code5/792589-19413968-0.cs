    public virtual string InnerText
    {
    	get
    	{
    		return HttpUtility.HtmlDecode(this.InnerHtml);
    	}
    	set
    	{
    		this.InnerHtml = HttpUtility.HtmlEncode(value);
    	}
    }
    public virtual string InnerHtml
    {
    	get
    	{
    		if (base.IsLiteralContent())
    		{
    			return ((LiteralControl)this.Controls[0]).Text;
    		}
    		if (this.HasControls() && this.Controls.Count == 1 && this.Controls[0] is DataBoundLiteralControl)
    		{
    			return ((DataBoundLiteralControl)this.Controls[0]).Text;
    		}
    		if (this.Controls.Count == 0)
    		{
    			return string.Empty;
    		}
    		throw new HttpException(SR.GetString("Inner_Content_not_literal", new object[]
    		{
    			this.ID
    		}));
    	}
    	set
    	{
    		this.Controls.Clear();
    		this.Controls.Add(new LiteralControl(value));
    		this.ViewState["innerhtml"] = value;
    	}
    }
