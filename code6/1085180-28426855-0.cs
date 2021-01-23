    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Windows.Data.Xml.Dom;
    using Windows.UI.Notifications;
    
    namespace ToastManager
    {
        class Win8Toaster
        {
            public const string APPUSERMODELID = "YourCompany.YourApplicationName";
            public static string ShortcutLocation;
            public static ToastNotifier ToastNotifier;
    
            private static Win8Toaster _INSTANCE = null;
            public static Win8Toaster INSTANCE
            {
                get
                {
                    if (_INSTANCE == null)
                    {
                        _INSTANCE = new Win8Toaster();
                    }
                    return _INSTANCE;
                }
            }
    
            public Win8Toaster()
            {
                ShortcutLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Start Menu\Programs\YourCompany\YourApplication.lnk");
                //We need a start menu shortcut (a ShellLink object) to show toasts.
                if (!File.Exists(ShortcutLocation))
                {
                    string directory = Path.GetDirectoryName(ShortcutLocation);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    using (ShellLink shortcut = new ShellLink())
                    {
                        shortcut.TargetPath = System.Reflection.Assembly.GetEntryAssembly().Location;
                        shortcut.Arguments = "";
                        shortcut.AppUserModelID = APPUSERMODELID;
                        shortcut.Save(ShortcutLocation);
                    }
                }
                ToastNotifier = ToastNotificationManager.CreateToastNotifier(APPUSERMODELID);
            }
    
            public void ShowToast(ToastContent Content)
            {
                XmlDocument ToastContent = new XmlDocument();
                ToastContent.LoadXml("<toast><visual><binding template=\"ToastImageAndText02\"><image id=\"1\" src=\"file:///" + Content.ImagePath + "\"/><text id=\"1\">" + Content.Text1 + "</text><text id=\"2\">" + Content.Text2 + "</text></binding></visual></toast>");
                ToastNotification thisToast = new ToastNotification(ToastContent);
                ToastNotifier.Show(thisToast);
            }                
        }
    }
