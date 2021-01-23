    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace ToastManager
    {
        public static class Toaster
        {
            private static Win8Toaster ActiveToaster;
            public static bool Win8ToasterAvailable = true;
            public static void ShowToast(ToastContent Content)
            {
                if (Win8ToasterAvailable)
                {
                    if (ActiveToaster == null)
                    {
                        if (Environment.OSVersion.Version.Major > 6 || Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor >= 2)
                        {
                            try
                            {
                                ActiveToaster = Win8Toaster.INSTANCE;
                            }
                            catch (Exception ex)
                            {
                                Win8ToasterAvailable = false;
                            }
                        }
                        else
                        {
                            Win8ToasterAvailable = false;
                        }
                    }
                    ActiveToaster.ShowToast(Content);
                }
                else
                {
                    //Use alternative notifications because Windows 8 Toasts are not available
                }
            }
        }
        //I also wrote my own toast content structure:
        public class ToastContent
        {
    
            public string ImagePath, Text1, Text2;
            public ToastContent(string ImagePath, string Text1, string Text2)
            {
                this.ImagePath = ImagePath;
                this.Text1 = Text1;
                this.Text2 = Text2;
            }
        }
    }
