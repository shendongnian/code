        using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace FixedFormWithAeroGlass
    {
       public class Form1 : Form
       {
          [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
          public struct DWM_BLURBEHIND
          {
             public uint dwFlags;
             [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
             public bool fEnable;
             public IntPtr hRegionBlur;
             [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
             public bool fTransitionOnMaximized;
    
             public const uint DWM_BB_ENABLE = 0x00000001;
             public const uint DWM_BB_BLURREGION = 0x00000002;
             public const uint DWM_BB_TRANSITIONONMAXIMIZED = 0x00000004;
          }
    
          [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
          public struct RECT
          {
             public int left, top, right, bottom;
    
             public RECT(int left, int top, int right, int bottom)
             {
                this.left = left; this.top = top;
                this.right = right; this.bottom = bottom;
             }
          }
    
          [System.Runtime.InteropServices.DllImport("dwmapi.dll", PreserveSig = false)]
          public static extern int DwmEnableBlurBehindWindow(System.IntPtr hWnd, ref DWM_BLURBEHIND pBlurBehind);
    
          public const int DWM_BB_ENABLE = 0x1;
          public const int DWM_BB_BLURREGION = 0x2;
          public const int DWM_BB_TRANSITIONONMAXIMIZED = 0x4;
    
          private System.ComponentModel.IContainer components = null;
    
          public Form1()
          {
             InitializeComponent();
    
             FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          }
    
          #region Windows Form Designer generated code
    
          private void InitializeComponent()
          {
             this.SuspendLayout();
             // 
             // Form1
             // 
             this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
             this.ClientSize = new System.Drawing.Size(470, 342);
             this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
             this.Name = "Form1";
             this.ResumeLayout(false);
    
          }
    
          #endregion
    
          protected override void OnPaintBackground(PaintEventArgs e)
          {
             base.OnPaintBackground(e);
    
             e.Graphics.Clear(BackColor);
             using (Brush b = new SolidBrush(Color.FromArgb(196, Color.Black)))
                e.Graphics.FillRectangle(b, ClientRectangle);
          }
    
          protected override void OnLoad(EventArgs e)
          {
             base.OnLoad(e);
    
             DWM_BLURBEHIND dbb;
             dbb.fEnable = true;
             dbb.dwFlags = DWM_BB_ENABLE | DWM_BB_BLURREGION;
    
             using (Graphics g = CreateGraphics())
                dbb.hRegionBlur = new Region(new Rectangle(0, 0, Width, Height)).GetHrgn(g);
             
             dbb.fTransitionOnMaximized = false;
             
             DwmEnableBlurBehindWindow(this.Handle, ref dbb);
          }
    
          protected override void Dispose(bool disposing)
          {
             if (disposing && (components != null))
             {
                components.Dispose();
             }
             base.Dispose(disposing);
          }
       }
    }
