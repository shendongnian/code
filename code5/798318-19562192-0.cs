        /// <summary>
        /// GetAppDatafolder
        /// </summary>
        private static void GetAppDatafolder(string otherUserName)
        {
            var currentUserIdentity = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            var currentUserName = (currentUserIdentity.Contains(@"\")) ? (currentUserIdentity.Split('\\')[1]) : currentUserIdentity;
            var currentAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var otherUserAppDataPath = currentAppDataPath.Replace(currentUserName, otherUserName);
            Console.WriteLine(string.Format("Current User AppDataPath : {0}", currentAppDataPath));
            Console.WriteLine(string.Format("{0} AppDataPath : {1}", otherUserName, otherUserAppDataPath));
        }
