    public partial class Form1 : Form
    {
        public Form1()
        {
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new ErrorProvider(this.components);
            this.textBox1 = new TextBox();
            this.textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(42, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Leave += this.textBox1_Leave;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(42, 52);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Leave += this.textBox2_Leave;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private void textBox1_Leave(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) {
                errorProvider1.SetError(textBox1, "REQUIRED FIELD");
            }
            else {
                errorProvider1.SetError(textBox1, string.Empty);
            }
        }
        private void textBox2_Leave(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "REQUIRED FIELD");
            }
            else
            {
                errorProvider1.SetError(textBox2, string.Empty);
            }
        }
    }
