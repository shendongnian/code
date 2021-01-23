    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.Diagnostics;
    using WinAPIs;
    
    namespace FileFolderWorker
    {
        #region Classes used as return values
        public class FolderProperties
        {
            #region Private class variables
            private string m_sPath = "";
            private Icon m_oIcon = null;
            #endregion
    
            #region Public class properties
            public string Path
            {
                get
                {
                    return m_sPath;
                }
                set
                {
                    m_sPath = value;
                }
            }
    
            public Icon Icon
            {
                get
                {
                    return m_oIcon;
                }
                set
                {
                    m_oIcon = value;
                }
            }
            #endregion
        }
        #endregion
    
        public static class SpecialFolders
        {
            #region Enums
            public enum FolderList
            {
                None,
                AdminTools,
                ApplicationData,
                CDBurning,
                CommonAdminTools,
                CommonApplicationData,
                CommonDesktopDirectory,
                CommonDocuments,
                CommonMusic,
                CommonOemLinks,
                CommonPictures,
                CommonProgramFiles,
                CommonProgramFilesX86,
                CommonPrograms,
                CommonStartMenu,
                CommonStartup,
                CommonTemplates,
                CommonVideos,
                Cookies,
                Desktop,
                DesktopDirectory,
                Favorites,
                Fonts,
                History,
                InternetCache,
                LocalApplicationData,
                LocalizedResources,
                MyComputer,
                MyDocuments,
                MyMusic,
                MyPictures,
                MyVideos,
                NetworkShortcuts,
                Personal,
                PrinterShortcuts,
                ProgramFiles,
                ProgramFilesX86,
                Programs,
                Recent,
                Resources,
                SendTo,
                StartMenu,
                Startup,
                System,
                SystemX86,
                Templates,
                UserProfile,
                Windows,
                Links,
            }
    
            public enum FolderType
            {
                None,
                System,
                Custom,
            }
            #endregion
    
            #region Public static class methods
            public static FolderProperties GetPath(string sFolderKey)
            {
                //Overloaded
                FolderList FolderKey = FolderList.None;
                //Determine the folder type
                switch (sFolderKey)
                {
                    #region System's Environment.SpecialFolder elements
                    //There was more code here but had to
                    //remove due to SO's character limit
                    //Full code: http://pastebin.com/dE0Y6tFB
                    case "System":
                        FolderKey = FolderList.System;
                        break;
                    case "SystemX86":
                        FolderKey = FolderList.SystemX86;
                        break;
                    case "Templates":
                        FolderKey = FolderList.Templates;
                        break;
                    case "UserProfile":
                        FolderKey = FolderList.UserProfile;
                        break;
                    case "Windows":
                        FolderKey = FolderList.Windows;
                        break;
                    #endregion
    
                    #region Custom elements
                    case "Links":
                        FolderKey = FolderList.Links;
                        break;
                    #endregion
                }
    
                return GetPath(FolderKey);
            }
            public static FolderProperties GetPath(FolderList FolderKey)
            {
                FolderProperties fp = new FolderProperties();
                FolderType sfType = FolderType.None;
                Environment.SpecialFolder sf = Environment.SpecialFolder.AdminTools;
    
                //Determine the folder type
                switch (FolderKey)
                {
                    #region System's Environment.SpecialFolder elements
                    //There was more code here but had to
                    //remove due to SO's character limit
                    //Full code: http://pastebin.com/dE0Y6tFB
                    case FolderList.System:
                        sfType = FolderType.System;
                        sf = Environment.SpecialFolder.System;
                        break;
                    case FolderList.SystemX86:
                        sfType = FolderType.System;
                        sf = Environment.SpecialFolder.SystemX86;
                        break;
                    case FolderList.Templates:
                        sfType = FolderType.System;
                        sf = Environment.SpecialFolder.Templates;
                        break;
                    case FolderList.UserProfile:
                        sfType = FolderType.System;
                        sf = Environment.SpecialFolder.UserProfile;
                        break;
                    case FolderList.Windows:
                        sfType = FolderType.System;
                        sf = Environment.SpecialFolder.Windows;
                        break;
                    #endregion
    
                    #region Custom elements
                    case FolderList.Links:
                        sfType = FolderType.Custom;
                        break;
                    #endregion
                }
    
                //Build the folder object's path
                switch (sfType)
                {
                    case FolderType.System:
                        fp.Path = Environment.GetFolderPath(sf);
                        break;
                    case FolderType.Custom:
                        fp.Path = "LINKS";
                        fp.Path = GetSpecialFolderPath(WinAPI.KnownFolder.Links);
                        break;
                }
    
                //Build the folder object's icon
                //more to be done here...
    
                return fp;
            }
    
            public static void DebugShowAllFolders()
            {
                foreach (SpecialFolders.FolderList sf in (SpecialFolders.FolderList[])Enum.GetValues(typeof(SpecialFolders.FolderList)))
                {
                    Debug.WriteLine("SpecialFolder: " + sf + "\n  Path: " + SpecialFolders.GetPath(sf.ToString()).Path + "\n");
                }
            }
    
            public static string GetSpecialFolderPath(Guid kFolderID)
            {
                string sRet = "";
    
                IntPtr pPath;
                if (WinAPI.SHGetKnownFolderPath(kFolderID, 0, IntPtr.Zero, out pPath) == 0)
                {
                    sRet = System.Runtime.InteropServices.Marshal.PtrToStringUni(pPath);
                    System.Runtime.InteropServices.Marshal.FreeCoTaskMem(pPath);
                }
    
                return sRet;
            }
            #endregion
        }
    }
