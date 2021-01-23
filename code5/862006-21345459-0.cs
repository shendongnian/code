    namespace MyTestApp
    {
        public static class Program
        {
            [System.STAThread]
            private static void Main ()
            {
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                System.Windows.Forms.Application.Run(new MyForm());
            }
            public class MyForm: System.Windows.Forms.Form
            {
                private System.Windows.Forms.Button ButtonClose { get; set; }
                private System.Windows.Forms.RichTextBox RichTextBox { get; set; }
                public MyForm ()
                {
                    this.ButtonClose = new System.Windows.Forms.Button();
                    this.RichTextBox = new System.Windows.Forms.RichTextBox();
                    this.ButtonClose.Text = "&Close";
                    this.ButtonClose.Click += new System.EventHandler(ButtonClose_Click);
                    this.Controls.Add(this.ButtonClose);
                    this.Controls.Add(this.RichTextBox);
                    this.Load += new System.EventHandler(MyForm_Load);
                }
                private void MyForm_Load (object sender, System.EventArgs e)
                {
                    int spacer = 4;
                    this.RichTextBox.Location = new System.Drawing.Point(spacer, spacer);
                    this.RichTextBox.Size = new System.Drawing.Size(this.ClientSize.Width - this.RichTextBox.Left - spacer, this.ClientSize.Height - this.RichTextBox.Top - spacer - this.ButtonClose.Height - spacer);
                    this.ButtonClose.Location = new System.Drawing.Point(this.ClientSize.Width - this.ButtonClose.Width - spacer, this.ClientSize.Height - this.ButtonClose.Height - spacer);
                }
                private void ButtonClose_Click (object sender, System.EventArgs e)
                {
                    this.Close();
                }
            }
        }
    }
