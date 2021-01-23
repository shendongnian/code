    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Interop;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    namespace IconTest2
    {
        public partial class MainWindow : Window
        {
            //Struct used by SHGetFileInfo function
            [StructLayout(LayoutKind.Sequential)]
            public struct SHFILEINFO
            {
                public IntPtr hIcon;
                public int iIcon;
                public uint dwAttributes;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
                public string szDisplayName;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
                public string szTypeName;
            };
    
            //Constants flags for SHGetFileInfo 
            public const uint SHGFI_ICON = 0x100;
    	  public const uint SHGFI_LARGEICON = 0x0; // 'Large icon
    		
            //Import SHGetFileInfo function
    	 [DllImport("shell32.dll")]
    	 public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
        
                public MainWindow()
                {
                    InitializeComponent();
                    SHFILEINFO shinfo = new SHFILEINFO();
        
                    //Call function with the path to the folder you want the icon for
                    SHGetFileInfo(
                        "C:\\Users\\Public\\Music",
                        0, ref shinfo,(uint)Marshal.SizeOf(shinfo),
                        SHGFI_ICON | SHGFI_LARGEICON);
        
                    using (Icon i = System.Drawing.Icon.FromHandle(shinfo.hIcon))
                    {
                        //Convert icon to a Bitmap source
                        ImageSource img = Imaging.CreateBitmapSourceFromHIcon(
                                                i.Handle,
                                                new Int32Rect(0, 0, i.Width, i.Height),
                                                BitmapSizeOptions.FromEmptyOptions());
        
                        //WPF Image control
                        m_image.Source = img;
                    }
                }
            }
        }
