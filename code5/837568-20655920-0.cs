	/// <summary>
	///  Avoid multiple submit
	/// </summary>
	/// <param name="button">The button.</param>
	/// <param name="text">text displayed on button</param>
	public void AvoidMultipleSubmit(Button button,string text="wait..." )
	{
		Page.ClientScript.RegisterOnSubmitStatement(GetType(), "ServerForm", "if(this.submitted) return false; this.submitted = true;");
		button.Attributes.Add("onclick", string.Format("if(typeof(Page_ClientValidate)=='function' && !Page_ClientValidate()){{return true;}}this.value='{1}';this.disabled=true;{0}",
			ClientScript.GetPostBackEventReference(button, string.Empty),text));
	}
