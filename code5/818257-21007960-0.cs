    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    using System.IO;
    using System.Management;
    public static class SVNManager
    {
        public enum AccessLevel : uint
        {
            NoAccess = 0, ReadOnly, ReadWrite
        }
        private static ManagementObject GetRepositoryObject(string name)
        {
            return new ManagementObject("root\\VisualSVN", string.Format("VisualSVN_Repository.Name='{0}'", name), null);
        }
        private static ManagementObject GetPermissionObject(string sid, AccessLevel accessLevel)
        {
            var accountClass = new ManagementClass("root\\VisualSVN",
                                               "VisualSVN_WindowsAccount", null);
            var entryClass = new ManagementClass("root\\VisualSVN",
                                             "VisualSVN_PermissionEntry", null);
            var account = accountClass.CreateInstance();
            account["SID"] = sid;
            var entry = entryClass.CreateInstance();
            entry["AccessLevel"] = accessLevel;
            entry["Account"] = account;
            return entry;
        }
        private static IDictionary<string, AccessLevel> GetPermissions(string repositoryName, string path)
        {
            var repository = GetRepositoryObject(repositoryName);
            var inParameters = repository.GetMethodParameters("GetSecurity");
            inParameters["Path"] = path;
            var outParameters = repository.InvokeMethod("GetSecurity", inParameters, null);
            var permissions = new Dictionary<string, AccessLevel>();
            foreach (var p in (ManagementBaseObject[])outParameters["Permissions"])
            {
                // NOTE: This will fail if VisualSVN Server is configured to use Subversion
                // authentication.  In that case you'd probably want to check if the account
                // is a VisualSVN_WindowsAccount or a VisualSVN_SubversionAccount instance
                // and tweak the property name accordingly.
                var account = (ManagementBaseObject)p["Account"];
                var sid = (string)account["SID"];
                var accessLevel = (AccessLevel)p["AccessLevel"];
                permissions[sid] = accessLevel;
            }
            return permissions;
        }
        private static void SetPermissions(string repositoryName, string path, IDictionary<string, AccessLevel> permissions)
        {
            var repository = GetRepositoryObject(repositoryName);
            var inParameters = repository.GetMethodParameters("SetSecurity");
        inParameters["Path"] = path;
 
            var permissionObjects = permissions.Select(p => GetPermissionObject(p.Key, p.Value));
            inParameters["Permissions"] = permissionObjects.ToArray();
            repository.InvokeMethod("SetSecurity", inParameters, null);
        }
        /// <summary>
        /// Will execute the commands needed to create a repository on the SVN server
        /// </summary>
        /// <param name="r">Object with the repository name.</param>
        /// <returns>True if creation was successful, False if there was a failure.</returns>
        static public bool CreateRepository(repository r)
        {
            ManagementClass repoClass = new ManagementClass("root\\VisualSVN", "VisualSVN_Repository", null);
            // Obtain in-parameters for the method
            ManagementBaseObject inParams = repoClass.GetMethodParameters("Create");
            // Add the input parameters.
            inParams["Name"] = r.name;
            // Execute the method and obtain the return values.
            ManagementBaseObject outParams =
                repoClass.InvokeMethod("Create", inParams, null);
            return true;
        }
    }
