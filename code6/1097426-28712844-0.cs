    public partial class Form1 : Form
    {
        [DllImport("coredll.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hWnd);
        [DllImport("coredll.dll")]
        public static extern Boolean ImmReleaseContext(IntPtr hWnd);
        [DllImport("coredll.dll")]
        public static extern Boolean ImmSetConversionStatus(IntPtr hIMC, Int32 fdwConversion, Int32 fdwSentence);
        
        [DllImport("coredll.dll")]
        public static extern Boolean ImmSetOpenStatus(IntPtr hIMC, Int32 fOpen);
         
        [DllImport("coredll.dll")]
        public static extern Int32 ImmAssociateContext(IntPtr hWnd, Int32 hIMC);
        public enum ImeMode { 
            NOCONTROL = 0,
            OFF = 1,
            ON = 2,
            DISABLE = 3,
            KOREAFULL = 4,
            KOREA = 5,
            ALPHAFULL = 6,
            ALPHA = 7
            };
        Int32 ALPHANUMERIC = 0x0; 
        Int32 NATIVE = 0x1;
        Int32 FULLSHAPE = 0x8;
        Int32 ROMAN = 0x10;
        public Form1()
        {
            InitializeComponent();
        }
        private void SetImeMode(Control ctrl, ImeMode mode)
        {
            IntPtr himc = ImmGetContext(ctrl.Handle);
            Int32 dwConversion = 0;
            try
            {
                switch (mode)
                {
                    case ImeMode.DISABLE:
                        ImmAssociateContext(himc, 0);
                        break;
                    case ImeMode.OFF:
                        ImmAssociateContext(himc, 1);
                        ImmSetOpenStatus(himc, 0);
                        break;
                    case ImeMode.ON:
                        ImmAssociateContext(himc, 1);
                        ImmSetOpenStatus(himc, 1);
                        break;
                    case ImeMode.KOREAFULL:
                        dwConversion = NATIVE | FULLSHAPE | ROMAN;
                        ImmSetConversionStatus(himc, dwConversion, 0);
                        break;
                    case ImeMode.KOREA:
                        dwConversion = NATIVE | ROMAN;
                        ImmSetConversionStatus(himc, dwConversion, 0);
                        break;
                    case ImeMode.ALPHAFULL:
                        dwConversion = FULLSHAPE | ALPHANUMERIC;
                        ImmSetConversionStatus(himc, dwConversion, 0);
                        break;
                    case ImeMode.ALPHA:
                        dwConversion = ALPHANUMERIC;
                        ImmSetConversionStatus(himc, dwConversion, 0);
                        break;
                }                
            }
            finally
            {
                ImmReleaseContext(ctrl.Handle);
            }
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            SetImeMode(textBox1, ImeMode.KOREA);
        }
    }
