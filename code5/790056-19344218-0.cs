    //Must add using System.Runtime.InteropServices;
    //We can define some extension method for this purpose
    public static class RichTextBoxExtension {
        [DllImport("user32")]
        private static extern int GetScrollInfo(IntPtr hwnd, int nBar, 
                                                ref SCROLLINFO scrollInfo);
        public struct SCROLLINFO {
          public int cbSize;
          public int fMask;
          public int min;
          public int max;
          public int nPage;
          public int nPos;
          public int nTrackPos;
        }
        public static bool ReachedBottom(this RichTextBox rtb){
           SCROLLINFO scrollInfo = new SCROLLINFO();
           scrollInfo.cbSize = Marshal.SizeOf(scrollInfo);
           //SIF_RANGE = 0x1, SIF_TRACKPOS = 0x10,  SIF_PAGE= 0x2
           scrollInfo.fMask = 0x10 | 0x1 | 0x2;
           GetScrollInfo(rtb.Handle, 1, ref scrollInfo);//nBar = 1 -> VScrollbar
           return scrollInfo.max == scrollInfo.nTrackPos + scrollInfo.nPage;
        }
    }
    //Usage:
    if(!yourRichTextBox.ReachedBottom()){
       yourRichTextBox.ScrollToCaret();
       //...
    }
