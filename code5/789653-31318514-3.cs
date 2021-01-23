	internal string ResolveVirtualPath(string virtualPath)
	{
		Uri uri;
		if (Uri.TryCreate(virtualPath, UriKind.Absolute, out uri))
		{
			return virtualPath;
		}
		string arg = "";
		if (this._httpContext.Request != null)
		{
			arg = this._httpContext.Request.AppRelativeCurrentExecutionFilePath;
		}
		return this.ResolveUrlMethod(arg, virtualPath);
	}
