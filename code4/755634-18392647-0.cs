    using System;
    using System.Windows.Forms;
    using System.Net;
    using System.IO;
    
    namespace Check_Website
    {
        public partial class Form1 : Form
        {
            String _previousSource = string.Empty;
            System.Windows.Forms.Timer timer;
    
            private System.Windows.Forms.CheckBox cbCheckWebsite;
            private System.Windows.Forms.TextBox tbOutput;
    
            public Form1()
            {
                InitializeComponent();
    
                this.cbCheckWebsite = new System.Windows.Forms.CheckBox();
                this.tbOutput = new System.Windows.Forms.TextBox();
                this.SuspendLayout();
                // 
                // cbCheckWebsite
                // 
                this.cbCheckWebsite.AutoSize = true;
                this.cbCheckWebsite.Location = new System.Drawing.Point(12, 12);
                this.cbCheckWebsite.Name = "cbCheckWebsite";
                this.cbCheckWebsite.Size = new System.Drawing.Size(80, 17);
                this.cbCheckWebsite.TabIndex = 0;
                this.cbCheckWebsite.Text = "checkBox1";
                this.cbCheckWebsite.UseVisualStyleBackColor = true;
                // 
                // tbOutput
                // 
                this.tbOutput.Location = new System.Drawing.Point(12, 35);
                this.tbOutput.Multiline = true;
                this.tbOutput.Name = "tbOutput";
                this.tbOutput.Size = new System.Drawing.Size(260, 215);
                this.tbOutput.TabIndex = 1;
                // 
                // Form1
                // 
                this.ClientSize = new System.Drawing.Size(284, 262);
                this.Controls.Add(this.tbOutput);
                this.Controls.Add(this.cbCheckWebsite);
                this.Name = "Form1";
                this.Load += new System.EventHandler(this.Form1_Load);
                this.ResumeLayout(false);
                this.PerformLayout();
    
                timer = new System.Windows.Forms.Timer();
                timer.Interval = 30000;
                timer.Tick += timer_Tick;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                timer.Start();
            }
    
            void timer_Tick(object sender, EventArgs e)
            {
                if (!cbCheckWebsite.Checked) return;
    
                WebRequest request = WebRequest.Create("http://localhost/check_website.html");
                request.Method = "GET";
    
                WebResponse response = request.GetResponse();
    
                string newContent;
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    newContent = sr.ReadToEnd();
                }
    
                tbOutput.Text += newContent + "\r\n";
    
                if (_previousSource == string.Empty)
                {
                    tbOutput.Text += "Nah. It's empty";
                }
                else if (_previousSource == newContent)
                {
                    tbOutput.Text += "Nah. Equals the old content";
                }
                else
                {
                    tbOutput.Text += "Oh great. Something happened";
                }
    
                _previousSource = newContent;
            }
        }
    }
