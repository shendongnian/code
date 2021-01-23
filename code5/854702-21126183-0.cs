    using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Windows.Forms;
        
        namespace Paint_Determinator_Form
        {
            public partial class Form1 : Form
            {
                public Form1()
                {
                    InitializeComponent();
                }
        
                private void button1_Click(object sender, EventArgs e)
                {
                    int length;
                    int width;
                    int height;
                    int paint;
                    int answer;
        
                        length = int.Parse(LengthtextBox.Text);
                        width = int.Parse(WidthtextBox.Text);
                        height = int.Parse(HeighttextBox.Text);
                        paint = 350;
        
                        answer = (length* width* height) / paint;
        
                        MessageBox.Show( answer.ToString() );
        
                }
        
            }
        }
        
        namespace Paint_Determinator_Form
        {
            partial class Form1
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
                    this.label1 = new System.Windows.Forms.Label();
                    this.label2 = new System.Windows.Forms.Label();
                    this.label3 = new System.Windows.Forms.Label();
                    this.label4 = new System.Windows.Forms.Label();
                    this.WidthtextBox = new System.Windows.Forms.TextBox();
                    this.HeighttextBox = new System.Windows.Forms.TextBox();
                    this.LengthtextBox = new System.Windows.Forms.TextBox();
                    this.button1 = new System.Windows.Forms.Button();
                    this.SuspendLayout();
                    // 
                    // label1
                    // 
                    this.label1.AutoSize = true;
                    this.label1.Location = new System.Drawing.Point(28, 29);
                    this.label1.Name = "label1";
                    this.label1.Size = new System.Drawing.Size(454, 13);
                    this.label1.TabIndex = 0;
                    this.label1.Text = "Welcome to Paint Determinator! Please enter the measurements in the appropriate f" +
            "ields below!";
                    // 
                    // label2
                    // 
                    this.label2.AutoSize = true;
                    this.label2.Location = new System.Drawing.Point(28, 91);
                    this.label2.Name = "label2";
                    this.label2.Size = new System.Drawing.Size(35, 13);
                    this.label2.TabIndex = 1;
                    this.label2.Text = "Width";
                    // 
                    // label3
                    // 
                    this.label3.AutoSize = true;
                    this.label3.Location = new System.Drawing.Point(28, 139);
                    this.label3.Name = "label3";
                    this.label3.Size = new System.Drawing.Size(38, 13);
                    this.label3.TabIndex = 2;
                    this.label3.Text = "Height";
                    // 
                    // label4
                    // 
                    this.label4.AutoSize = true;
                    this.label4.Location = new System.Drawing.Point(28, 183);
                    this.label4.Name = "label4";
                    this.label4.Size = new System.Drawing.Size(40, 13);
                    this.label4.TabIndex = 3;
                    this.label4.Text = "Length";
                    // 
                    // WidthtextBox
                    // 
                    this.WidthtextBox.Location = new System.Drawing.Point(175, 83);
                    this.WidthtextBox.Name = "WidthtextBox";
                    this.WidthtextBox.Size = new System.Drawing.Size(100, 20);
                    this.WidthtextBox.TabIndex = 5;
                    // 
                    // HeighttextBox
                    // 
                    this.HeighttextBox.Location = new System.Drawing.Point(175, 131);
                    this.HeighttextBox.Name = "HeighttextBox";
                    this.HeighttextBox.Size = new System.Drawing.Size(100, 20);
                    this.HeighttextBox.TabIndex = 6;
                    // 
                    // LengthtextBox
                    // 
                    this.LengthtextBox.Location = new System.Drawing.Point(175, 183);
                    this.LengthtextBox.Name = "LengthtextBox";
                    this.LengthtextBox.Size = new System.Drawing.Size(100, 20);
                    this.LengthtextBox.TabIndex = 7;
                    // 
                    // button1
                    // 
                    this.button1.Location = new System.Drawing.Point(349, 402);
                    this.button1.Name = "button1";
                    this.button1.Size = new System.Drawing.Size(75, 23);
                    this.button1.TabIndex = 9;
                    this.button1.Text = "Paint";
                    this.button1.UseVisualStyleBackColor = true;
                    // 
                    // Form1
                    // 
                    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                    this.ClientSize = new System.Drawing.Size(511, 447);
                    this.Controls.Add(this.button1);
                    this.Controls.Add(this.LengthtextBox);
                    this.Controls.Add(this.HeighttextBox);
                    this.Controls.Add(this.WidthtextBox);
                    this.Controls.Add(this.label4);
                    this.Controls.Add(this.label3);
                    this.Controls.Add(this.label2);
                    this.Controls.Add(this.label1);
                    this.Name = "Form1";
                    this.Text = "Form1";
                    this.ResumeLayout(false);
                    this.PerformLayout();
        
                }
        
                #endregion
        
                private System.Windows.Forms.Label label1;
                private System.Windows.Forms.Label label2;
                private System.Windows.Forms.Label label3;
                private System.Windows.Forms.Label label4;
                private System.Windows.Forms.TextBox WidthtextBox;
                private System.Windows.Forms.TextBox HeighttextBox;
                private System.Windows.Forms.TextBox LengthtextBox;
                private System.Windows.Forms.Button button1;
            }
