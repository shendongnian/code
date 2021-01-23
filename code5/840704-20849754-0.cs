    public class IconHelper
    {
        // Constants that we need in the function call
        private const int SHGFI_ICON = 0x100;
        private const int SHGFI_SMALLICON = 0x1;
        private const int SHGFI_LARGEICON = 0x0;
        private const int SHIL_JUMBO = 0x4;
        private const int SHIL_EXTRALARGE = 0x2;
        // This structure will contain information about the file
        public struct SHFILEINFO
        {
            // Handle to the icon representing the file
            public IntPtr hIcon;
            // Index of the icon within the image list
            public int iIcon;
            // Various attributes of the file
            public uint dwAttributes;
            // Path to the file
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string szDisplayName;
            // File type
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };
        [System.Runtime.InteropServices.DllImport("Kernel32.dll")]
        public static extern Boolean CloseHandle(IntPtr handle);
        private struct IMAGELISTDRAWPARAMS
        {
            public int cbSize;
            public IntPtr himl;
            public int i;
            public IntPtr hdcDst;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public int xBitmap;        // x offest from the upperleft of bitmap
            public int yBitmap;        // y offset from the upperleft of bitmap
            public int rgbBk;
            public int rgbFg;
            public int fStyle;
            public int dwRop;
            public int fState;
            public int Frame;
            public int crEffect;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct IMAGEINFO
        {
            public IntPtr hbmImage;
            public IntPtr hbmMask;
            public int Unused1;
            public int Unused2;
            public Rect rcImage;
        }
        [DllImport("shell32.dll", EntryPoint = "#727")]
        private extern static int SHGetImageList(
            int iImageList,
            ref Guid riid,
            out IImageList ppv
            );
        // The signature of SHGetFileInfo (located in Shell32.dll)
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        public static extern int SHGetFileInfo(string pszPath, int dwFileAttributes, ref SHFILEINFO psfi, int cbFileInfo, uint uFlags);
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        public static extern int SHGetFileInfo(IntPtr pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, int cbFileInfo, uint uFlags);
        [DllImport("shell32.dll", SetLastError = true)]
        static extern int SHGetSpecialFolderLocation(IntPtr hwndOwner, Int32 nFolder,
                 ref IntPtr ppidl);
        [DllImport("user32")]
        public static extern int DestroyIcon(IntPtr hIcon);
        public struct pair
        {
            public System.Drawing.Icon icon { get; set; }
            public IntPtr iconHandleToDestroy { set; get; }
        }
        private static byte[] ByteFromIcon(System.Drawing.Icon ic)
        {
            var icon = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(ic.Handle,
                                                    System.Windows.Int32Rect.Empty,
                                                    System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
            icon.Freeze();
            byte[] data;
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(icon));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }
    private static byte[] GetSmallIcon(string FileName, IconSize iconSize)
        {
            SHFILEINFO shinfo = new SHFILEINFO();
            uint flags;
            if (iconSize == IconSize.Small)
            {
                flags = SHGFI_ICON | SHGFI_SMALLICON;
            }
            else
            {
                flags = SHGFI_ICON | SHGFI_LARGEICON;
            }
            var res = SHGetFileInfo(FileName, 0, ref shinfo, Marshal.SizeOf(shinfo), flags);
            if (res == 0)
            {
                throw (new System.IO.FileNotFoundException());
            }
            var ico = (System.Drawing.Icon)System.Drawing.Icon.FromHandle(shinfo.hIcon);
            var bs = ByteFromIcon(ico);
            ico.Dispose();
            DestroyIcon(shinfo.hIcon);
            return bs;
        }
        private static byte[] GetLargeIcon(string FileName)
        {
            SHFILEINFO shinfo = new SHFILEINFO();
            uint SHGFI_SYSICONINDEX = 0x4000;
            int FILE_ATTRIBUTE_NORMAL = 0x80;
            uint flags;
            flags = SHGFI_SYSICONINDEX;
            var res = SHGetFileInfo(FileName, FILE_ATTRIBUTE_NORMAL, ref shinfo, Marshal.SizeOf(shinfo), flags);
            if (res == 0)
            {
                throw (new System.IO.FileNotFoundException());
            }
            var iconIndex = shinfo.iIcon;
            Guid iidImageList = new Guid("46EB5926-582E-4017-9FDF-E8998DAA0950");
            IImageList iml;
            int size = SHIL_EXTRALARGE;
            var hres = SHGetImageList(size, ref iidImageList, out  iml); // writes iml
            IntPtr hIcon = IntPtr.Zero;
            int ILD_TRANSPARENT = 1;
            hres = iml.GetIcon(iconIndex, ILD_TRANSPARENT, ref hIcon);
            var ico = System.Drawing.Icon.FromHandle(hIcon);
            var bs = ByteFromIcon(ico);
            ico.Dispose();
            DestroyIcon(hIcon);
            return bs;
        }
    }
