    private Task Impersonate()
	{
		if (As == null)
			return this;
		Log.Debug("[As] {0}", As);
		IntPtr token;
		if (!CredRead(As, 1, 0, out token))
			throw new Win32Exception();
		var cred = (Credential)Marshal.PtrToStructure(token, typeof(Credential));
		CredFree(token);
		var name = cred.UserName.Split('\\');
		var user = new { Name = name[1], Domain = name[0], Password = Marshal.PtrToStringAuto(cred.CredentialBlob) };
		Log.Info("[As] {0}\\{1}", user.Domain, user.Name);
		if (!LogonUser(user.Name, user.Domain, user.Password, 9, 0, out token))
			throw new Win32Exception();
		Context = WindowsIdentity.Impersonate(token);
		if (!CloseHandle(token))
			throw new Win32Exception();
		return this;
	}
	private struct Credential
	{
		#pragma warning disable 169, 649
		public uint Flags;
		public uint Type;
		public string TargetName;
		public string Comment;
		public System.Runtime.InteropServices.ComTypes.FILETIME LastWritten;
		public uint CredentialBlobSize;
		public IntPtr CredentialBlob;
		public uint Persist;
		public uint AttributeCount;
		public IntPtr Attributes;
		public string TargetAlias;
		public string UserName;
		#pragma warning restore 169, 649
	}
