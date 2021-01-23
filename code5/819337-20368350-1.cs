            public static void FolderPermission(String accountName, String folderPath)
        {try
            {
                FileSystemRights Rights;
                //What rights are we setting? Here accountName is == "IIS_IUSRS"
                Rights = FileSystemRights.FullControl;
                bool modified;
                var none = new InheritanceFlags();
                none = InheritanceFlags.None;
                //set on dir itself
                var accessRule = new FileSystemAccessRule(accountName, Rights, none, PropagationFlags.NoPropagateInherit, AccessControlType.Allow);
                var dInfo = new DirectoryInfo(folderPath);
                var dSecurity = dInfo.GetAccessControl();
                dSecurity.ModifyAccessRule(AccessControlModification.Set, accessRule, out modified);
                //Always allow objects to inherit on a directory 
                var iFlags = new InheritanceFlags();
                iFlags = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;
                //Add Access rule for the inheritance
                var accessRule2 = new FileSystemAccessRule(accountName, Rights, iFlags, PropagationFlags.InheritOnly, AccessControlType.Allow);
                dSecurity.ModifyAccessRule(AccessControlModification.Add, accessRule2, out modified);
                dInfo.SetAccessControl(dSecurity);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }
