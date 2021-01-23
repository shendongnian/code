    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1() {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e) {
                var shinfo = new Win32.SHFILEINFO();
                Win32.SHGetFileInfo("0000000000.DOCX", 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_SMALLICON | Win32.SHGFI_USEFILEATTRIBUTES);
                var icon = (Icon)Icon.FromHandle(shinfo.hIcon).Clone();
                Win32.DestroyIcon(shinfo.hIcon);
                this.BackgroundImage = icon.ToBitmap();
                icon.Dispose();
            }
    
            private class Win32 {
                internal const uint SHGFI_ICON = 0x100;
                internal const uint SHGFI_SMALLICON = 0x1;
                internal const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;
    
                [DllImport("user32.dll", SetLastError = true)]
                [return: MarshalAs(UnmanagedType.Bool)]
                internal static extern bool DestroyIcon(IntPtr hIcon);
    
                [DllImport("shell32.dll")]
                internal static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
    
                [StructLayout(LayoutKind.Sequential)]
                internal struct SHFILEINFO
                {
                    public IntPtr hIcon;
                    public IntPtr iIcon;
                    public uint dwAttributes;
    
                    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
                    public string szDisplayName;
    
                    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
                    public string szTypeName;
                }
            }
        }
    }
