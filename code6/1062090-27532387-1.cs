    public static class StepHelper
    {
        [DllImport("User32.dll")]
        public static extern Int32 FindWindow(String lpClassName, String lpWindowName);
        public static WatiN.Core.Native.Windows.Window GetAlertBox()
        {
            IntPtr hwndTmp = (IntPtr)FindWindow("#32770", "Message from webpage");
            return new WatiN.Core.Native.Windows.Window(hwndTmp);
        }
    }
