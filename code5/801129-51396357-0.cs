    using System;
    using System.Runtime.InteropServices;
    
    public class MsgBox
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    
        [DllImport("user32.dll")]
        static extern bool EndDialog(IntPtr hDlg, int nResult);
    
        [DllImport("user32.dll")]
        static extern int MessageBoxTimeout(IntPtr hwnd, string txt, string caption,
            int wtype, int wlange, int dwtimeout);
    
        const int WM_CLOSE = 0x10;
    
        public static int Show(string text, string caption, int milliseconds, MsgBoxStyle style)
        {
            return MessageBoxTimeout(IntPtr.Zero, text, caption, (int)style, 0, milliseconds);
        }
    
        public static int Show(string text, string caption, int milliseconds, int style)
        {
            return MessageBoxTimeout(IntPtr.Zero, text, caption, style, 0, milliseconds);
        }
        public static int Show(string text, string caption, int milliseconds)
        {
            return MessageBoxTimeout(IntPtr.Zero, text, caption, 0, 0, milliseconds);
        }
    }
    
    public enum MsgBoxStyle
    {
        OK = 0, OKCancel = 1, AbortRetryIgnore = 2, YesNoCancel = 3, YesNo = 4,
        RetryCancel = 5, CancelRetryContinue = 6,
    
        RedCritical_OK = 16, RedCritical_OKCancel = 17, RedCritical_AbortRetryIgnore = 18,
        RedCritical_YesNoCancel = 19, RedCritical_YesNo = 20,
        RedCritical_RetryCancel = 21, RedCritical_CancelRetryContinue = 22,
    
        BlueQuestion_OK = 32, BlueQuestion_OKCancel = 33, BlueQuestion_AbortRetryIgnore = 34,
        BlueQuestion_YesNoCancel = 35, BlueQuestion_YesNo = 36,
        BlueQuestion_RetryCancel = 37, BlueQuestion_CancelRetryContinue = 38,
    
        YellowAlert_OK = 48, YellowAlert_OKCancel = 49, YellowAlert_AbortRetryIgnore = 50,
        YellowAlert_YesNoCancel = 51, YellowAlert_YesNo = 52,
        YellowAlert_RetryCancel = 53, YellowAlert_CancelRetryContinue = 54,
    
        BlueInfo_OK = 64, BlueInfo_OKCancel = 65, BlueInfo_AbortRetryIgnore = 66,
        BlueInfo_YesNoCancel = 67, BlueInfo_YesNo = 68,
        BlueInfo_RetryCancel = 69, BlueInfo_CancelRetryContinue = 70,
    }
