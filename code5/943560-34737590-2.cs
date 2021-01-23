    void fnCreateShellFolder(string strGUID, string strFolderTitle, string strTargetFolderPath, string strIconPath)
    {
        RegistryKey localKey, keyTemp;
        if (Environment.Is64BitOperatingSystem)
            localKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
        else
            localKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32);
        localKey = localKey.CreateSubKey(@"Software\Classes\CLSID\{" + strGUID + "}");
        localKey.SetValue("", strFolderTitle, RegistryValueKind.String);
        localKey.SetValue("System.IsPinnedToNameSpaceTree", unchecked((int)0x1), RegistryValueKind.DWord);
        localKey.SetValue("SortOrderIndex", unchecked((int)0x42), RegistryValueKind.DWord);
        keyTemp = localKey.CreateSubKey(@"DefaultIcon");
        keyTemp.SetValue("", strIconPath, RegistryValueKind.ExpandString);
        keyTemp.Close();
        keyTemp = localKey.CreateSubKey(@"InProcServer32");
        keyTemp.SetValue("", @"%systemroot%\system32\shell32.dll", RegistryValueKind.ExpandString);
        keyTemp.Close();
        keyTemp = localKey.CreateSubKey(@"Instance");
        keyTemp.SetValue("CLSID", "{0E5AAE11-A475-4c5b-AB00-C66DE400274E}", RegistryValueKind.String);
        keyTemp.Close();
        keyTemp = localKey.CreateSubKey(@"Instance\InitPropertyBag");
        keyTemp.SetValue("Attributes", unchecked((int)0x11), RegistryValueKind.DWord);
        keyTemp.SetValue("TargetFolderPath", strTargetFolderPath, RegistryValueKind.ExpandString);
        keyTemp.Close();
        keyTemp = localKey.CreateSubKey(@"ShellFolder");
        keyTemp.SetValue("FolderValueFlags", unchecked((int)0x28), RegistryValueKind.DWord);
        keyTemp.SetValue("Attributes", unchecked((int)0xF080004D), RegistryValueKind.DWord);
        keyTemp.Close();
        localKey.Close();
        localKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
        keyTemp = localKey.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace\{" + strGUID + "}");
        keyTemp.SetValue("", strFolderTitle, RegistryValueKind.String);
        keyTemp.Close();
        keyTemp = localKey.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel");
        keyTemp.SetValue("{" + strGUID + "}", unchecked((int)0x1), RegistryValueKind.DWord);
        keyTemp.Close();
    }
