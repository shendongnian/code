    using System;
    using System.Text;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    public class NewMessageBox : Form
    {
        private TextBox textBoxMessage;
        private Button buttonOK;
        
    
        public NewMessageBox(string title, string message)
        {
            InitializeComponent();
            this.Text = title;
            this.textBoxMessage.Text = message;
            this.Deactivate += MyDeactivateHandler;
            this.textBoxMessage.ReadOnly = true;
        }
    
    
        private void InitializeComponent()
        {
                this.buttonOK = new System.Windows.Forms.Button();
                this.textBoxMessage = new System.Windows.Forms.TextBox();
                this.SuspendLayout();
                // 
                // buttonOK
                // 
                this.buttonOK.Location = new System.Drawing.Point(171, 161);
                this.buttonOK.Name = "buttonOK";
                this.buttonOK.Size = new System.Drawing.Size(107, 44);
                this.buttonOK.TabIndex = 0;
                this.buttonOK.Text = "OK";
                this.buttonOK.UseVisualStyleBackColor = true;
                this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
                // 
                // textBoxMessage
                // 
                this.textBoxMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.textBoxMessage.Location = new System.Drawing.Point(29, 36);
                this.textBoxMessage.Name = "textBoxMessage";
                this.textBoxMessage.ReadOnly = true;
                this.textBoxMessage.Size = new System.Drawing.Size(411, 38);
                this.textBoxMessage.TabIndex = 1;
                // 
                // NewMessageBox
                // 
                this.ClientSize = new System.Drawing.Size(468, 236);
                this.Controls.Add(this.textBoxMessage);
                this.Controls.Add(this.buttonOK);
                this.Name = "NewMessageBox";
                this.Load += new System.EventHandler(this.NewMessageBox_Load);
                this.ResumeLayout(false);
                this.PerformLayout();
    
        }
    
    
        public string message { get; set; }
    
        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
        protected void MyDeactivateHandler(object sender, EventArgs e)
        {
            this.Close();
        }
    
        private void NewMessageBox_Load(object sender, EventArgs e)
        {
    
        }
    
        
    }
