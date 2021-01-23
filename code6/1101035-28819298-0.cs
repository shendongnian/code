    var s = "WinNT://" + Environment.UserDomainName + "/" + Environment.UserName;
    using (System.Security.Principal.WindowsIdentity.Impersonate(IntPtr.Zero))
    using (var de = new System.DirectoryServices.DirectoryEntry(s))
    {
      ViewBag.Username = de.Properties["fullName"].Value.ToString();
    }
