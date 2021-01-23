    // Untested code, but it might look like this...
    // (Add exception handling as necessary)
    Process process = Process.GetCurrentProcess();
    using (new PrivilegeEnabler(process, Privilege.Security))
    {
        // Privilege is enabled within the using block.
        File.Copy(originFile, destinationFile);
        FileInfo originFileInfo = new FileInfo(originFile);
        FileInfo destinationFileInfo = new FileInfo(destinationFile);
        FileSecurity ac1 = originFileInfo.GetAccessControl(AccessControlSections.All);
        ac1.SetAccessRuleProtection(true, true);
        destinationFileInfo.SetAccessControl(ac1);
    }
