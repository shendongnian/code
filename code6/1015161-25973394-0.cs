    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
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
                Application.Run(new MainForm());
            }
    
            // form which contains the web browser
            public partial class MainForm : Form
            {
                public WebBrowser web = new WebBrowser();
                public MainForm()
                {
    
    
                    web.Height = this.Height;
                    web.Width = this.Width;
                    web.Top = 0;
                    web.Left = 0;
                    web.Dock = DockStyle.Fill;
                    this.Controls.Add(web);
                   
                    web.Navigate("http://www.google.com");
                }
                protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
                {
                    if (keyData == (Keys.Control | Keys.U))
                    {
                        SourceForm scr = new SourceForm(this.web);
                        scr.Show();
    
                        return true;
                    }
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }
    
    
            //the form which will be shown once you press CTRL+U
            public class SourceForm : Form
            {
                public TextBox sourceText;
                public SourceForm(WebBrowser web)
                {
                    sourceText = new TextBox();
                    sourceText.Multiline = true;
                    sourceText.ScrollBars = ScrollBars.Both;
                    sourceText.Left = 0;
                    sourceText.Top = 0;
                    sourceText.Dock = DockStyle.Fill;
                    sourceText.Height = this.Height;
                    sourceText.Width = this.Width;
                    this.Controls.Add(sourceText);
                    this.sourceText.Text = web.DocumentText;
                    this.Text = web.DocumentTitle;
                }
            }
           
        }
    }
