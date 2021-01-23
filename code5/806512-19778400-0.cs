    using System;
    using System.Windows.Forms;
    using System.Threading;
    using Microsoft.Office.Interop.Excel;
    using System.Runtime.InteropServices;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            Thread someWorkerThread;
    
            Microsoft.Office.Interop.Excel.Application ExApp;
            Worksheet wrkSheet;
    
            public Form1()
            {
                InitializeComponent();
    
                ExApp = new Microsoft.Office.Interop.Excel.Application();
    
                ExApp.Visible = true; // or else we won't see the window
    
                var books = ExApp.Workbooks;
                var wrkBook = books.Add();
                var sheets = wrkBook.Worksheets;
                wrkSheet = sheets.get_Item(1);
    
                Marshal.ReleaseComObject(sheets);
                Marshal.ReleaseComObject(wrkBook);
                Marshal.ReleaseComObject(books);
    
                someWorkerThread = new Thread(new ParameterizedThreadStart(threadHandler));
                someWorkerThread.Start(this);
            }
    
            private void threadHandler(object obj)
            {// this will be executed on a seperate worker thread
                Control mainFrm = obj as Control;
                if (mainFrm == null)
                    throw new ArgumentException("Need to have a Control as parameter");
                for (int i = 1; i < 50;i++ )
                {
                    Thread.Sleep(2500);
                    mainFrm.Invoke(new Action<int>(doStuff), i); // this will invoke the main UI thread
                }
            }
    
            private void doStuff(int i)
            {// this will be executed on the main UI thread
                var range = wrkSheet.Range[string.Format("A{0}", i)];
                range.Value = "Hello World!";
                Marshal.ReleaseComObject(range);
            }
    
    
            #region designer stuff
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
                this.label1 = new System.Windows.Forms.Label();
                this.SuspendLayout();
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(76, 84);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(149, 13);
                this.label1.TabIndex = 0;
                this.label1.Text = "I am an ordinary windows form";
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(284, 262);
                this.Controls.Add(this.label1);
                this.Name = "Form1";
                this.Text = "Form1";
                this.ResumeLayout(false);
                this.PerformLayout();
    
            }
    
            #endregion
    
            private System.Windows.Forms.Label label1;
    
            #endregion
        }
    }
