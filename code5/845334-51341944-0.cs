        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Diagnostics;
        using System.Drawing;
        using System.Runtime.InteropServices;
        using System.Text;
        using System.Windows.Forms;
        using mshtml;
    
        namespace HookBrowser
        {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            #region API CALLS
    
            [DllImport("user32.dll", EntryPoint = "GetClassNameA")]
            public static extern int GetClassName(IntPtr hwnd, StringBuilder lpClassName, int nMaxCount);
    
            /*delegate to handle EnumChildWindows*/
            public delegate int EnumProc(IntPtr hWnd, ref IntPtr lParam);
    
            [DllImport("user32.dll")]
            public static extern int EnumChildWindows(IntPtr hWndParent, EnumProc lpEnumFunc, ref  IntPtr lParam);
            [DllImport("user32.dll", EntryPoint = "RegisterWindowMessageA")]
            public static extern int RegisterWindowMessage(string lpString);
            [DllImport("user32.dll", EntryPoint = "SendMessageTimeoutA")]
            public static extern int SendMessageTimeout(IntPtr hwnd, int msg, int wParam, int lParam, int fuFlags, int uTimeout, out int lpdwResult);
            [DllImport("OLEACC.dll")]
            public static extern int ObjectFromLresult(int lResult, ref Guid riid, int wParam, ref IHTMLDocument2 ppvObject);
            public const int SMTO_ABORTIFHUNG = 0x2;
            public Guid IID_IHTMLDocument = new Guid("626FC520-A41E-11CF-A731-00A0C9082637");
    
            #endregion
    
            public IHTMLDocument2 document;
    
            private void button1_Click(object sender, EventArgs e)
            {
                document = documentFromDOM();
                /// check that we have hold of the IHTMLDocument2...
                if (!(bool)(document == null))
                {
                    this.Text = document.url;
                }
            }
    
            private IHTMLDocument2 documentFromDOM()
            {
                Process[] processes = Process.GetProcessesByName("iexplore");
                if (processes.Length > 0)
                {
                    IntPtr hWnd = processes[0].MainWindowHandle;
                    int lngMsg = 0;
                    int lRes;
    
                    EnumProc proc = new EnumProc(EnumWindows);
                    EnumChildWindows(hWnd, proc, ref hWnd);
                    if (!hWnd.Equals(IntPtr.Zero))
                    {
                        lngMsg = RegisterWindowMessage("WM_HTML_GETOBJECT");
                        if (lngMsg != 0)
                        {
                            SendMessageTimeout(hWnd, lngMsg, 0, 0, SMTO_ABORTIFHUNG, 1000, out lRes);
                            if (!(bool)(lRes == 0))
                            {
                                int hr = ObjectFromLresult(lRes, ref IID_IHTMLDocument, 0, ref document);
                                if ((bool)(document == null))
                                {
                                    MessageBox.Show("NoLDocument Found!", "Warning");
                                }
                            }
                        }
                    }
                }
                return document;
            }
    
            private int EnumWindows(IntPtr hWnd, ref IntPtr lParam)
            {
                int retVal = 1;
                StringBuilder classname = new StringBuilder(128);
                GetClassName(hWnd, classname, classname.Capacity);
                /// check if the instance we have found is Internet Explorer_Server
                if ((bool)(string.Compare(classname.ToString(), "Internet Explorer_Server") == 0))
                {
                    lParam = hWnd;
                    retVal = 0;
                }
                return retVal;
            }
        }
    }
