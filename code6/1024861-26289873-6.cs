    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            MyModelClass model = new MyModelClass();
            public Form1()
            {
                InitializeComponent();
                model.AnotherColor = model.AColor = System.Drawing.Color.FromKnownColor(KnownColor.Control);
                bindingSource1.DataSource = model;
                this.DataBindings.Add("BackColor", bindingSource1, "AColor");
                this.DataBindings.Add("Visible", bindingSource1, "ABool");
                new Form2(model).Show();
            }
    
            private BindingSource bindingSource1;
            private Button button1;
            private Button button2;
            private Button button3;
            private Button button4;
            private Button button5;
    
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
                this.components = new System.ComponentModel.Container();
                this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
                this.button1 = new System.Windows.Forms.Button();
                this.button2 = new System.Windows.Forms.Button();
                this.button3 = new System.Windows.Forms.Button();
                this.button4 = new System.Windows.Forms.Button();
                this.button5 = new System.Windows.Forms.Button();
                ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
                this.SuspendLayout();
                // 
                // button1
                // 
                this.button1.Location = new System.Drawing.Point(12, 12);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(127, 23);
                this.button1.TabIndex = 0;
                this.button1.Text = "Form2 -> green";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click);
                // 
                // button2
                // 
                this.button2.Location = new System.Drawing.Point(12, 41);
                this.button2.Name = "button2";
                this.button2.Size = new System.Drawing.Size(127, 23);
                this.button2.TabIndex = 1;
                this.button2.Text = "Form2 -> red";
                this.button2.UseVisualStyleBackColor = true;
                this.button2.Click += new System.EventHandler(this.button2_Click);
                // 
                // button3
                // 
                this.button3.Location = new System.Drawing.Point(12, 70);
                this.button3.Name = "button3";
                this.button3.Size = new System.Drawing.Size(127, 23);
                this.button3.TabIndex = 2;
                this.button3.Text = "Form2 -> Visible";
                this.button3.UseVisualStyleBackColor = true;
                this.button3.Click += new System.EventHandler(this.button3_Click);
                // 
                // button4
                // 
                this.button4.Location = new System.Drawing.Point(12, 99);
                this.button4.Name = "button4";
                this.button4.Size = new System.Drawing.Size(127, 23);
                this.button4.TabIndex = 3;
                this.button4.Text = "Form2 -> Invisible";
                this.button4.UseVisualStyleBackColor = true;
                this.button4.Click += new System.EventHandler(this.button4_Click);
                // 
                // button5
                // 
                this.button5.Location = new System.Drawing.Point(46, 159);
                this.button5.Name = "button5";
                this.button5.Size = new System.Drawing.Size(106, 42);
                this.button5.TabIndex = 4;
                this.button5.Text = "some important form1 button";
                this.button5.UseVisualStyleBackColor = true;
                this.button5.Click += new System.EventHandler(this.button5_Click);
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(284, 262);
                this.Controls.Add(this.button5);
                this.Controls.Add(this.button4);
                this.Controls.Add(this.button3);
                this.Controls.Add(this.button2);
                this.Controls.Add(this.button1);
                this.Name = "Form1";
                this.Text = "Form1";
                ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
                this.ResumeLayout(false);
    
            }
    
            #endregion
    
            private void button1_Click(object sender, EventArgs e)
            {
                model.AnotherColor = Color.Green;
                model.doSomething();
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                model.AnotherColor = Color.Red;
                model.doSomething();
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                model.AnotherBool = true;
            }
    
            private void button4_Click(object sender, EventArgs e)
            {
                model.AnotherBool = false;
            }
    
            private void button5_Click(object sender, EventArgs e)
            {
                model.someImportantMethod();
            }
        }
    }
