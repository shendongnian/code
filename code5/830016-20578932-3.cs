    namespace DeveloperWorkbench.UI
    {
        partial class Form2
        {
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
                this.button1 = new System.Windows.Forms.Button();
                this.progressBar1 = new System.Windows.Forms.ProgressBar();
                this.lblProgress = new System.Windows.Forms.Label();
                this.SuspendLayout();
                // 
                // button1
                // 
                this.button1.Location = new System.Drawing.Point(13, 13);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(207, 23);
                this.button1.TabIndex = 0;
                this.button1.Text = "Start Sql Server";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click);
                // 
                // progressBar1
                // 
                this.progressBar1.Location = new System.Drawing.Point(13, 42);
                this.progressBar1.Name = "progressBar1";
                this.progressBar1.Size = new System.Drawing.Size(207, 23);
                this.progressBar1.TabIndex = 1;
                // 
                // lblProgress
                // 
                this.lblProgress.AutoSize = true;
                this.lblProgress.Location = new System.Drawing.Point(227, 22);
                this.lblProgress.Name = "lblProgress";
                this.lblProgress.Size = new System.Drawing.Size(35, 13);
                this.lblProgress.TabIndex = 2;
                this.lblProgress.Text = "label1";
                // 
                // Form2
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(303, 74);
                this.Controls.Add(this.lblProgress);
                this.Controls.Add(this.progressBar1);
                this.Controls.Add(this.button1);
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.Name = "Form2";
                this.Text = "Service Status";
                this.ResumeLayout(false);
                this.PerformLayout();
    
            }
    
            #endregion
    
            private System.Windows.Forms.Button button1;
            private System.Windows.Forms.ProgressBar progressBar1;
            private System.Windows.Forms.Label lblProgress;
        }
    }
