    using System;
    using System.Windows.Forms;
    namespace App
    {
        public partial class DemoForm : Form
        {
            private Awesomium.Windows.Forms.WebControl web;
            public DemoForm()
            {
                InitializeComponent();
                doSomeScrap();
            }
            public void doSomeScrap()
            {
                MessageBox.Show("in the scrapper...");
                web.DocumentReady += webcontrolEventListener;
                web.Source = new Uri("http://www.google.com");
                web.Update();
            }
            private void webcontrolEventListener(object sender, EventArgs e)
            {
                MessageBox.Show("in the listener!");
            }
            private void InitializeComponent()
            {
                this.SuspendLayout();
                this.web = new Awesomium.Windows.Forms.WebControl();
                this.web.Dock = System.Windows.Forms.DockStyle.Fill;
                this.Controls.Add(this.web);
                this.ClientSize = new System.Drawing.Size(800, 600);
                this.Name = "DemoForm";
                this.Text = "DemoForm";
                this.ResumeLayout(false);
            }
        }
    }
