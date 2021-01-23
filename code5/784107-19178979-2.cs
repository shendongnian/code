    /// <summary>
    /// Copies the SecurityPermissions object specified by the securityPermissions input parameter into the computer clipboard in the SecurityPermissions format.
    /// </summary>
    /// <param name="securityPermissions">The SecurityPermissions object to copy into the computer clipboard.</param>
    public void SetClipboardSecurityPermissions(SecurityPermissions securityPermissions)
    {
        try { SetClipboardSecurityPermissionsData(securityPermissions); }
        catch (COMException)
        {
            Thread.Sleep(0);
            try { SetClipboardSecurityPermissionsData(securityPermissions); }
            catch (COMException)
            {
                MessageBox.Show("The clipboard was inaccessible, please try again later");
            }
        }
    }
    private void SetClipboardSecurityPermissionsData(SecurityPermissions userSecurityPermissions)
    {
        List<SecurityPermission> securityPermissions = new List<SecurityPermission>(userSecurityPermissions);
        List<SerializableSecurityPermission> serializableSecurityPermissions = new List<SerializableSecurityPermission>();
        foreach (SecurityPermission securityPermission in securityPermissions) serializableSecurityPermissions.Add(new SerializableSecurityPermission(securityPermission));
        DataObject securityPermissionsDataObject = new DataObject();
        securityPermissionsDataObject.SetData("SecurityPermissions", serializableSecurityPermissions, false);
        Clipboard.SetDataObject(securityPermissionsDataObject);
    }
    /// <summary>
    /// Retrieves a SecurityPermissions object from the computer clipboard if any data exists in the SecurityPermissions format.
    /// </summary>
    public SecurityPermissions GetClipboardSecurityPermissions()
    {
        if (HasClipboardGotDataFormat("SecurityPermissions"))
        {
            try { return PasteClipboardSecurityPermissions(); }
            catch (COMException)
            {
                Thread.Sleep(0);
                try { return PasteClipboardSecurityPermissions(); }
                catch (COMException)
                {
                    MessageBox.Show("The clipboard was inaccessible, please try again later");
                }
            }
        }
        return new SecurityPermissions();
    }
    private SecurityPermissions PasteClipboardSecurityPermissions()
    {
        object data = Clipboard.GetData("SecurityPermissions");
        if (data != null)
        {
            List<SecurityPermission> securityPermissions = new List<SecurityPermission>();
            List<SerializableSecurityPermission> serializableSecurityPermissions = (List<SerializableSecurityPermission>)data;
            foreach(SerializableSecurityPermission serializableSecurityPermission in serializableSecurityPermissions) securityPermissions.Add(new SecurityPermission(serializableSecurityPermission));
            return new SecurityPermissions(securityPermissions);
        }
        return new SecurityPermissions();
    }
