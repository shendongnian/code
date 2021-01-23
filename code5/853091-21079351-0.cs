    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form,ISomeCallbackInterface
        {
            #region designer stuff
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
                this.textBox1 = new System.Windows.Forms.TextBox();
                this.textBox2 = new System.Windows.Forms.TextBox();
                this.textBox3 = new System.Windows.Forms.TextBox();
                this.button1 = new System.Windows.Forms.Button();
                this.button2 = new System.Windows.Forms.Button();
                this.SuspendLayout();
                // 
                // textBox1
                // 
                this.textBox1.Location = new System.Drawing.Point(65, 49);
                this.textBox1.Name = "textBox1";
                this.textBox1.Size = new System.Drawing.Size(100, 20);
                this.textBox1.TabIndex = 0;
                // 
                // textBox2
                // 
                this.textBox2.Location = new System.Drawing.Point(65, 75);
                this.textBox2.Name = "textBox2";
                this.textBox2.Size = new System.Drawing.Size(100, 20);
                this.textBox2.TabIndex = 1;
                // 
                // textBox3
                // 
                this.textBox3.Location = new System.Drawing.Point(65, 101);
                this.textBox3.Name = "textBox3";
                this.textBox3.Size = new System.Drawing.Size(100, 20);
                this.textBox3.TabIndex = 2;
                // 
                // button1
                // 
                this.button1.Location = new System.Drawing.Point(65, 173);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(100, 23);
                this.button1.TabIndex = 3;
                this.button1.Text = "do something";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click);
                // 
                // button2
                // 
                this.button2.Location = new System.Drawing.Point(65, 202);
                this.button2.Name = "button2";
                this.button2.Size = new System.Drawing.Size(100, 35);
                this.button2.TabIndex = 4;
                this.button2.Text = "do something with a callback";
                this.button2.UseVisualStyleBackColor = true;
                this.button2.Click += new System.EventHandler(this.button2_Click);
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(284, 262);
                this.Controls.Add(this.button2);
                this.Controls.Add(this.button1);
                this.Controls.Add(this.textBox3);
                this.Controls.Add(this.textBox2);
                this.Controls.Add(this.textBox1);
                this.Name = "Form1";
                this.Text = "Form1";
                this.ResumeLayout(false);
                this.PerformLayout();
    
            }
    
            #endregion
    
            private System.Windows.Forms.TextBox textBox1;
            private System.Windows.Forms.TextBox textBox2;
            private System.Windows.Forms.TextBox textBox3;
            private Button button2;
            private System.Windows.Forms.Button button1;
    
            #endregion
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                var x = SomeOtherClassDoingStuff.DoSomethingThatReturns();
                HandleSomeReturnValue(x);
            }
            
            private void button2_Click(object sender, EventArgs e)
            {
                SomeOtherClassDoingStuff.DoSomethingByCallbackInterface(this);
            }
            
            void ISomeCallbackInterface.TheActualCallback(SomeRetrunValueClass theValueReturnedToTheCallback)
            {
                HandleSomeReturnValue(theValueReturnedToTheCallback);
            }
    
            private void HandleSomeReturnValue(SomeRetrunValueClass theValue)
            {
                textBox1.Text = theValue.A.ToString();
                textBox2.Text = theValue.B.ToString();
                textBox3.Text = theValue.C;
            }
    
            
        }
    
        public interface ISomeCallbackInterface
        {
            void TheActualCallback(SomeRetrunValueClass theValueReturnedToTheCallback);
        }
    
        public class SomeOtherClassDoingStuff
        {
            public static SomeRetrunValueClass DoSomethingThatReturns()
            {
                return new SomeRetrunValueClass { A = 123, B = 0.456, C = "Something" };
            }
    
            public static void DoSomethingByCallbackInterface(ISomeCallbackInterface Callback) 
            {
                Callback.TheActualCallback(new SomeRetrunValueClass { A = 234, B = 0.567, C = "Something else" });
            }
        }
    
        public class SomeRetrunValueClass
        {
            public int A { get; set; }
            public double B { get; set; }
            public String C { get; set; }
        }
    
    }
