	private void GetDelegateInformationWithNoAssert(IDictionary dictionary)
	{
		if (this is Page)
		{
			this.GetDelegateInformationFromMethod("Page_PreInit", dictionary);
			this.GetDelegateInformationFromMethod("Page_PreLoad", dictionary);
			this.GetDelegateInformationFromMethod("Page_LoadComplete", dictionary);
			this.GetDelegateInformationFromMethod("Page_PreRenderComplete", dictionary);
			this.GetDelegateInformationFromMethod("Page_InitComplete", dictionary);
			this.GetDelegateInformationFromMethod("Page_SaveStateComplete", dictionary);
		}
		this.GetDelegateInformationFromMethod("Page_Init", dictionary);
		this.GetDelegateInformationFromMethod("Page_Load", dictionary);
		this.GetDelegateInformationFromMethod("Page_DataBind", dictionary);
		this.GetDelegateInformationFromMethod("Page_PreRender", dictionary);
		this.GetDelegateInformationFromMethod("Page_Unload", dictionary);
		this.GetDelegateInformationFromMethod("Page_Error", dictionary);
		if (!this.GetDelegateInformationFromMethod("Page_AbortTransaction", dictionary))
		{
			this.GetDelegateInformationFromMethod("OnTransactionAbort", dictionary);
		}
		if (!this.GetDelegateInformationFromMethod("Page_CommitTransaction", dictionary))
		{
			this.GetDelegateInformationFromMethod("OnTransactionCommit", dictionary);
		}
	}
