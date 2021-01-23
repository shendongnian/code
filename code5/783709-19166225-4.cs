    namespace testScreenCapScale
    {
        partial class Form1
        {
            private System.ComponentModel.IContainer components = null;
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                    components.Dispose();
                base.Dispose(disposing);
            }
            private void InitializeComponent()
            {
                this.printDocument1 = new System.Drawing.Printing.PrintDocument();
                this.button1 = new System.Windows.Forms.Button();
                this.SuspendLayout();
                // 
                // printDocument1
                // 
                this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
                // 
                // button1
                // 
                this.button1.Location = new System.Drawing.Point(64, 220);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(75, 23);
                this.button1.TabIndex = 0;
                this.button1.Text = "button1";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click);
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(384, 377);
                this.Controls.Add(this.button1);
                this.Name = "Form1";
                this.Text = "Form1";
                this.ResumeLayout(false);
            }
            private System.Drawing.Printing.PrintDocument printDocument1;
            private System.Windows.Forms.Button button1;
        }
    }
