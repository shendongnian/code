    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Microsoft.Office.Interop.Word;
    using System.IO;
    namespace WordControls
    {
        public partial class DocBrowser : UserControl
        {
            private System.Windows.Forms.WebBrowser webBrowser1;
        delegate void ConvertDocumentDelegate(string fileName);
        public DocBrowser()
        {
            InitializeComponent();
            // Create the webBrowser control on the UserControl. 
            // This code was moved from the designer for cut and paste
            // ease. 
            webBrowser1 = new System.Windows.Forms.WebBrowser();
            webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            webBrowser1.Location = new System.Drawing.Point(0, 0);
            webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            webBrowser1.Name = "webBrowser1";
            webBrowser1.Size = new System.Drawing.Size(532, 514);
            webBrowser1.TabIndex = 0;
            Controls.Add(webBrowser1);
            // set up an event handler to delete our temp file when we're done with it. 
            webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
        }
        string tempFileName = null;
        public void LoadDocument(string fileName)
        {
            // Call ConvertDocument asynchronously. 
            ConvertDocumentDelegate del = new ConvertDocumentDelegate(ConvertDocument);
            // Call DocumentConversionComplete when the method has completed. 
            del.BeginInvoke(fileName, DocumentConversionComplete, null);
        }
        void ConvertDocument(string fileName)
        {
            object m = System.Reflection.Missing.Value;
            object oldFileName = (object)fileName;
            object readOnly = (object)false;
            ApplicationClass ac = null;
            try
            {
                // First, create a new Microsoft.Office.Interop.Word.ApplicationClass.
                ac = new ApplicationClass();
                // Now we open the document.
                Document doc = ac.Documents.Open(ref oldFileName, ref m, ref readOnly,
                    ref m, ref m, ref m, ref m, ref m, ref m, ref m,
                     ref m, ref m, ref m, ref m, ref m, ref m);
                // Create a temp file to save the HTML file to. 
                tempFileName = GetTempFile("html");
                // Cast these items to object.  The methods we're calling 
                // only take object types in their method parameters. 
                object newFileName = (object)tempFileName;
                // We will be saving this file as HTML format. 
                object fileType = (object)WdSaveFormat.wdFormatHTML;
                // Save the file. 
                doc.SaveAs(ref newFileName, ref fileType,
                    ref m, ref m, ref m, ref m, ref m, ref m, ref m,
                    ref m, ref m, ref m, ref m, ref m, ref m, ref m);
            }
            finally
            {
                // Make sure we close the application class. 
                if (ac != null)
                    ac.Quit(ref readOnly, ref m, ref m);
            }
        }
        void DocumentConversionComplete(IAsyncResult result)
        {
            // navigate to our temp file. 
            webBrowser1.Navigate(tempFileName);
        }
        void webBrowser1_DocumentCompleted(object sender,
            WebBrowserDocumentCompletedEventArgs e)
        {
            if (tempFileName != string.Empty)
            {
                // delete the temp file we created. 
                File.Delete(tempFileName);
                // set the tempFileName to an empty string. 
                tempFileName = string.Empty;
            }
        }
        string GetTempFile(string extension)
        {
            // Uses the Combine, GetTempPath, ChangeExtension, 
            // and GetRandomFile methods of Path to 
            // create a temp file of the extension we're looking for. 
            return Path.Combine(Path.GetTempPath(),
                Path.ChangeExtension(Path.GetRandomFileName(), extension));
            }
        }
    }
