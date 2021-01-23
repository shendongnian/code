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
        public partial class Form2 : Form
        {
            MyModelClass model;
            private Button button4;
            private Button button3;
            private Button button5;
            int callCounter = 0;
            public Form2(MyModelClass model)
            {
                InitializeComponent();
                this.model = model;
                bindingSource1.DataSource = model;
                DataBindings.Add("BackColor", bindingSource1, "AnotherColor");
                this.DataBindings.Add("Visible", bindingSource1, "AnotherBool");
    
                model.PropertyChanged += new PropertyChangedEventHandler(model_PropertyChanged);
            }
    
            void model_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                label1.Text = String.Format("PropertyChanged was called {0} times.", ++callCounter);
            }
    
            private BindingSource bindingSource1;
            private Button button2;
            private Button button1;
            private Label label1;
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
                this.button2 = new System.Windows.Forms.Button();
                this.button1 = new System.Windows.Forms.Button();
                this.label1 = new System.Windows.Forms.Label();
                this.button4 = new System.Windows.Forms.Button();
                this.button3 = new System.Windows.Forms.Button();
                this.button5 = new System.Windows.Forms.Button();
                ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
                this.SuspendLayout();
                // 
                // button2
                // 
                this.button2.Location = new System.Drawing.Point(18, 41);
                this.button2.Name = "button2";
                this.button2.Size = new System.Drawing.Size(127, 23);
                this.button2.TabIndex = 3;
                this.button2.Text = "Form1 -> red";
                this.button2.UseVisualStyleBackColor = true;
                this.button2.Click += new System.EventHandler(this.button2_Click);
                // 
                // button1
                // 
                this.button1.Location = new System.Drawing.Point(18, 12);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(127, 23);
                this.button1.TabIndex = 2;
                this.button1.Text = "Form1 -> green";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click);
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(15, 231);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(181, 13);
                this.label1.TabIndex = 4;
                this.label1.Text = "PropertyChanged was called 0 times.";
                // 
                // button4
                // 
                this.button4.Location = new System.Drawing.Point(18, 99);
                this.button4.Name = "button4";
                this.button4.Size = new System.Drawing.Size(127, 23);
                this.button4.TabIndex = 6;
                this.button4.Text = "Form1 -> Invisible";
                this.button4.UseVisualStyleBackColor = true;
                this.button4.Click += new System.EventHandler(this.button4_Click);
                // 
                // button3
                // 
                this.button3.Location = new System.Drawing.Point(18, 70);
                this.button3.Name = "button3";
                this.button3.Size = new System.Drawing.Size(127, 23);
                this.button3.TabIndex = 5;
                this.button3.Text = "Form1 -> Visible";
                this.button3.UseVisualStyleBackColor = true;
                this.button3.Click += new System.EventHandler(this.button3_Click);
                // 
                // button5
                // 
                this.button5.Location = new System.Drawing.Point(154, 164);
                this.button5.Name = "button5";
                this.button5.Size = new System.Drawing.Size(94, 40);
                this.button5.TabIndex = 7;
                this.button5.Text = "some less important button";
                this.button5.UseVisualStyleBackColor = true;
                this.button5.Click += new System.EventHandler(this.button5_Click);
                // 
                // Form2
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(284, 262);
                this.Controls.Add(this.button5);
                this.Controls.Add(this.button4);
                this.Controls.Add(this.button3);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.button2);
                this.Controls.Add(this.button1);
                this.Name = "Form2";
                this.Text = "Form2";
                ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();
    
            }
    
            #endregion
    
            private void button1_Click(object sender, EventArgs e)
            {
                model.AColor = Color.Green;
                model.doSomething();
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                model.AColor = Color.Red;
                model.doSomething();
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                model.ABool = true;
            }
    
            private void button4_Click(object sender, EventArgs e)
            {
                model.ABool = false;
            }
    
            private void button5_Click(object sender, EventArgs e)
            {
                MessageBox.Show("some less important button was clicked ... \nnow calling the same method that's called from form1's important button");
                model.someImportantMethod();
            }
        }
    }
