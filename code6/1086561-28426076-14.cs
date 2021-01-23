    public static class RichTextBoxConstants
    {
        // http://referencesource.microsoft.com/#System.Windows.Forms/winforms/Managed/System/WinForms/RichTextBoxConstants.cs,31b52ac41e96a888
        /* EM_SETCHARFORMAT wparam masks */
        internal const int SCF_SELECTION = 0x0001;
        internal const int EM_SETCHARFORMAT = (NativeMethods.WM_USER + 68);
        internal const int CFM_BACKCOLOR = 0x04000000;
        /* NOTE: CFE_AUTOCOLOR and CFE_AUTOBACKCOLOR correspond to CFM_COLOR and
           CFM_BACKCOLOR, respectively, which control them */
        internal const int CFE_AUTOBACKCOLOR = CFM_BACKCOLOR;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class CHARFORMAT2
    {
        // http://referencesource.microsoft.com/#System.Windows.Forms/winforms/Managed/System/WinForms/NativeMethods.cs,acde044a28b57a48
        // http://pinvoke.net/default.aspx/Structures/CHARFORMAT2.html
        public int cbSize = Marshal.SizeOf(typeof(CHARFORMAT2));
        public int dwMask;
        public int dwEffects;
        public int yHeight;
        public int yOffset;
        public int crTextColor;
        public byte bCharSet;
        public byte bPitchAndFamily;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string szFaceName;
        public short wWeight;
        public short sSpacing;
        public int crBackColor;
        public int lcid;
        public int dwReserved;
        public short sStyle;
        public short wKerning;
        public byte bUnderlineType;
        public byte bAnimation;
        public byte bRevAuthor;
        public byte bReserved1;
    }
    public static class NativeMethods
    {
        // http://referencesource.microsoft.com/#System.Windows.Forms/winforms/Managed/System/WinForms/NativeMethods.cs,e75041b5218ff60b
        public const int WM_USER = 0x0400;
        public static void SetSelectionBackColor(this RichTextBox richTextBox, Color value)
        {
            if (richTextBox.IsHandleCreated && value == Color.Empty)
            {
                var cf2 = new CHARFORMAT2();
                cf2.dwEffects = RichTextBoxConstants.CFE_AUTOBACKCOLOR;
                cf2.dwMask = RichTextBoxConstants.CFM_BACKCOLOR;
                cf2.crBackColor = ColorTranslator.ToWin32(value);
                UnsafeNativeMethods.SendMessage(new HandleRef(richTextBox, richTextBox.Handle), RichTextBoxConstants.EM_SETCHARFORMAT, RichTextBoxConstants.SCF_SELECTION, cf2);
            }
            else
            {
                richTextBox.SelectionBackColor = value;
            }
        }
    }
    public static class UnsafeNativeMethods
    {
        // http://referencesource.microsoft.com/#System.Windows.Forms/winforms/Managed/System/WinForms/UnsafeNativeMethods.cs,0d546f58103867e3
        // For RichTextBox
        //
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, [In, Out, MarshalAs(UnmanagedType.LPStruct)] CHARFORMAT2 lParam);
    }
