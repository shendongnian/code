    using System;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace FileSecurityProperties
    {
        public partial class FileSelectorForm : Form
        {
            private static bool ShowFileSecurityProperties(string Filename, IntPtr parentHandle)
            {
                SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();
                info.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(info);
                info.lpVerb = "properties";
                info.lpFile = Filename;
                info.nShow = SW_SHOW;
                info.fMask = SEE_MASK_INVOKEIDLIST;
                info.hwnd = parentHandle;
                info.lpParameters = "Security"; // Opens the file properties on the Security tab
                return ShellExecuteEx(ref info);
            }
            private void fileSelectButton_Click(object sender, EventArgs e)
            {
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ShowFileSecurityProperties(
                        openFileDialog.FileName,
                        this.Handle); // Pass parent window handle for properties dialog
                }
            }
            #region P/Invoke code for ShellExecuteEx from https://stackoverflow.com/a/1936957/4486839
            [DllImport("shell32.dll", CharSet = CharSet.Auto)]
            static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
            public struct SHELLEXECUTEINFO
            {
                public int cbSize;
                public uint fMask;
                public IntPtr hwnd;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string lpVerb;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string lpFile;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string lpParameters;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string lpDirectory;
                public int nShow;
                public IntPtr hInstApp;
                public IntPtr lpIDList;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string lpClass;
                public IntPtr hkeyClass;
                public uint dwHotKey;
                public IntPtr hIcon;
                public IntPtr hProcess;
            }
            private const int SW_SHOW = 5;
            private const uint SEE_MASK_INVOKEIDLIST = 12;
            #endregion
            #region Irrelevant Windows forms code
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;
            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            #region Windows Form Designer generated code
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
                this.fileSelectButton = new System.Windows.Forms.Button();
                this.SuspendLayout();
                // 
                // openFileDialog1
                // 
                this.openFileDialog.FileName = "";
                // 
                // fileSelectButton
                // 
                this.fileSelectButton.Location = new System.Drawing.Point(52, 49);
                this.fileSelectButton.Name = "fileSelectButton";
                this.fileSelectButton.Size = new System.Drawing.Size(131, 37);
                this.fileSelectButton.TabIndex = 0;
                this.fileSelectButton.Text = "Select file ...";
                this.fileSelectButton.UseVisualStyleBackColor = true;
                this.fileSelectButton.Click += new System.EventHandler(this.fileSelectButton_Click);
                // 
                // FileSelectorForm
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(248, 162);
                this.Controls.Add(this.fileSelectButton);
                this.Name = "FileSelectorForm";
                this.Text = "File Selector";
                this.ResumeLayout(false);
            }
            #endregion
            private System.Windows.Forms.OpenFileDialog openFileDialog;
            private System.Windows.Forms.Button fileSelectButton;
            public FileSelectorForm()
            {
                InitializeComponent();
            }
            #endregion
        }
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FileSelectorForm());
            }
        }
    }
