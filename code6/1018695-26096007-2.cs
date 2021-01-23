    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace AddingControlsInAeroStyleForm
    {
       public class Form1 : Form
       {
          [System.Runtime.InteropServices.DllImport("dwmapi.dll", PreserveSig = false)]
          public static extern void DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMargins);
    
          [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
          public struct MARGINS
          {
             public int Left, Right, Top, Bottom;
    
             public MARGINS(int left, int top, int right, int bottom)
             {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
             }
    
             public MARGINS(int margin)
             {
                Left = margin;
                Top = margin;
                Right = margin;
                Bottom = margin;
             }
          }
    
          private System.Windows.Forms.Panel panel1;
          private System.Windows.Forms.Button button1;
    
          /// <summary>
          /// Required designer variable.
          /// </summary>
          private System.ComponentModel.IContainer components = null;
    
          public Form1()
          {
             InitializeComponent();
    
             MARGINS margins = new MARGINS(-1);
    
             DwmExtendFrameIntoClientArea(this.Handle, ref margins);
          }
    
          private void Form1_Load(object sender, EventArgs e)
          {
             this.TransparencyKey = Color.FromArgb(255, Color.Black);
             panel1.BackColor = Color.FromArgb(255, Color.Black);
    
          }
    
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
             this.panel1 = new System.Windows.Forms.Panel();
             this.button1 = new System.Windows.Forms.Button();
             this.panel1.SuspendLayout();
             this.SuspendLayout();
             // 
             // panel1
             // 
             this.panel1.Controls.Add(this.button1);
             this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
             this.panel1.Location = new System.Drawing.Point(0, 0);
             this.panel1.Name = "panel1";
             this.panel1.Size = new System.Drawing.Size(374, 303);
             this.panel1.TabIndex = 0;
             // 
             // button1
             // 
             this.button1.FlatAppearance.BorderSize = 0;
             this.button1.Location = new System.Drawing.Point(202, 23);
             this.button1.Name = "button1";
             this.button1.Size = new System.Drawing.Size(125, 70);
             this.button1.TabIndex = 0;
             this.button1.UseVisualStyleBackColor = true;
             // 
             // Form1
             // 
             this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
             this.ClientSize = new System.Drawing.Size(374, 303);
             this.Controls.Add(this.panel1);
             this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
             this.MaximizeBox = false;
             this.MinimizeBox = false;
             this.Name = "Form1";
             this.Text = "Form1";
             this.Load += new System.EventHandler(this.Form1_Load);
             this.panel1.ResumeLayout(false);
             this.ResumeLayout(false);
    
          }
    
          #endregion
    
          
       }
    }
