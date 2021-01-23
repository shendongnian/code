	public override string ToString()
	{
		return this.ToString(true, true);
	}
	private string ToString(bool needFileLineInfo, bool needMessage)
	{
		string text = needMessage ? this.Message : null;
		string text2;
		if (text == null || text.Length <= 0)
		{
			text2 = this.GetClassName();
		}
		else
		{
			text2 = this.GetClassName() + ": " + text;
		}
		if (this._innerException != null)
		{
			text2 = string.Concat(new string[]
			{
				text2,
				" ---> ",
				this._innerException.ToString(needFileLineInfo, needMessage),
				Environment.NewLine,
				"   ",
				Environment.GetRuntimeResourceString("Exception_EndOfInnerExceptionStack")
			});
		}
		string stackTrace = this.GetStackTrace(needFileLineInfo);
		if (stackTrace != null)
		{
			text2 = text2 + Environment.NewLine + stackTrace;
		}
		return text2;
	}
