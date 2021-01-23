        private static bool SetAccess(string user, string folder)
        {
            const FileSystemRights Rights = FileSystemRights.FullControl;
            // *** Add Access Rule to the actual directory itself
            var AccessRule = new FileSystemAccessRule(user, Rights,
                InheritanceFlags.None,
                PropagationFlags.NoPropagateInherit,
                AccessControlType.Allow);
            var Info = new DirectoryInfo(folder);
            var Security = Info.GetAccessControl(AccessControlSections.Access);
            bool Result;
            Security.ModifyAccessRule(AccessControlModification.Set, AccessRule, out Result);
            if (!Result) return false;
            // *** Always allow objects to inherit on a directory
            const InheritanceFlags iFlags = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;
            // *** Add Access rule for the inheritance
            AccessRule = new FileSystemAccessRule(user, Rights,
                iFlags,
                PropagationFlags.InheritOnly,
                AccessControlType.Allow);
            Security.ModifyAccessRule(AccessControlModification.Add, AccessRule, out Result);
            if (!Result) return false;
            Info.SetAccessControl(Security);
            return true;
        } 
