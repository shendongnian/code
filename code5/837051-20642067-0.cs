    using System;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            static void Main()
            {
                ChatForm chatForm = new ChatForm();
                chatForm.PostMessage("Ash", "test",
                    DateTime.Today + new TimeSpan(18, 0, 0));
                chatForm.PostMessage("Bob", "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    DateTime.Today + new TimeSpan(18, 5, 0));
                Application.Run(chatForm);
            }
        }
        class ChatForm : Form
        {
            public ChatForm()
            {
                InitializeComponent();
            }
            private int userMaxWidth = 8;
            private int msgMaxWidth = 40;
            public void PostMessage(string user, string msg, DateTime time)
            {
                // Truncate user
                if (user.Length > userMaxWidth)
                    user = user.Substring(0, userMaxWidth);
                // Trucate msg
                if (msg.Length > msgMaxWidth)
                    msg = msg.Substring(0, msgMaxWidth);
                string compositeString = 
                    "#{0,-" + userMaxWidth + "}{1,-" + msgMaxWidth + "}{2:HH:mm}";
                string formattedMsg =
                    String.Format(compositeString, user, msg, time);
                
                textBox.AppendText(formattedMsg);
                textBox.AppendText(Environment.NewLine);
                textBox.AppendText(Environment.NewLine);
            }
            private System.Windows.Forms.TextBox textBox;
            private void InitializeComponent()
            {
                this.textBox = new System.Windows.Forms.TextBox();
                this.SuspendLayout();
                // 
                // textBox
                // 
                this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
                this.textBox.Font = new System.Drawing.Font("Courier New", 8.25F,
                    System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.textBox.Location = new System.Drawing.Point(0, 0);
                this.textBox.Multiline = true;
                this.textBox.WordWrap = false;
                this.textBox.Name = "textBox";
                this.textBox.Size = new System.Drawing.Size(500, 200);
                this.textBox.TabIndex = 0;
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(500, 200);
                this.Controls.Add(this.textBox);
                this.Name = "ChatForm";
                this.Text = "ChatForm";
                this.ResumeLayout(false);
                this.PerformLayout();
            }
        }
    }
