    You can use SendMessage to send WM_MOUSEWHEEL message to the second control:
    SendMessage(destWindowHandle, m.Msg, (int)m.WParam, (int)m.LParam);
    
    Here is sample with 2 listboxes, scrolling one scrolls another.
    
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace WindowsFormsApplication18
    {
       static class Program
       {
          /// <summary>
          /// The main entry point for the application.
          /// </summary>
          [STAThread]
          static void Main()
          {
             Application.EnableVisualStyles();
             Application.SetCompatibleTextRenderingDefault(false);
             Application.Run(new Form1());
          }
    
    
    
       }
    
       public class MessageFilter : IMessageFilter
       {
          IntPtr sourceWindowHandle;
          IntPtr destWindowHandle;
    
    
          [DllImport("user32.dll", CharSet = CharSet.Auto)]
          public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
    
          public MessageFilter(IntPtr sourceHandle, IntPtr destHandle)
          {
             sourceWindowHandle = sourceHandle;
             destWindowHandle = destHandle;
          }
          public bool PreFilterMessage(ref Message m)
          {
             if (m.HWnd == sourceWindowHandle && m.Msg == 0x020A)// mousewheel
                SendMessage(destWindowHandle, m.Msg, (int)m.WParam, (int)m.LParam);
             return false;
          }
       }
    
    
    
       public class Form1 : Form
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
             this.listBox1 = new System.Windows.Forms.ListBox();
             this.listBox2 = new System.Windows.Forms.ListBox();
             this.SuspendLayout();
             // 
             // listBox1
             // 
             this.listBox1.FormattingEnabled = true;
             this.listBox1.Items.AddRange(new object[] {
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10"});
             this.listBox1.Location = new System.Drawing.Point(56, 48);
             this.listBox1.Name = "listBox1";
             this.listBox1.Size = new System.Drawing.Size(120, 95);
             this.listBox1.TabIndex = 0;
             // 
             // listBox2
             // 
             this.listBox2.FormattingEnabled = true;
             this.listBox2.Items.AddRange(new object[] {
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10"});
             this.listBox2.Location = new System.Drawing.Point(280, 48);
             this.listBox2.Name = "listBox2";
             this.listBox2.Size = new System.Drawing.Size(120, 95);
             this.listBox2.TabIndex = 1;
             // 
             // Form1
             // 
             this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
             this.ClientSize = new System.Drawing.Size(501, 361);
             this.Controls.Add(this.listBox2);
             this.Controls.Add(this.listBox1);
             this.Name = "Form1";
             this.Text = "Form1";
             this.ResumeLayout(false);
    
          }
    
          #endregion
    
          private System.Windows.Forms.ListBox listBox1;
          private System.Windows.Forms.ListBox listBox2;
          public Form1()
          {
             InitializeComponent();
             Application.AddMessageFilter(new MessageFilter(listBox1.Handle, listBox2.Handle));
    
          }
    
    
       }
    }
