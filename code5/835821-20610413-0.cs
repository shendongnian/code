    using System;
    using System.Collections.Generic;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    using System.Linq;
    using System.Text;
    
    namespace WindowsFormsApplication1
    {
        public class RoundButton : Button
        {
        
            protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
            {
                GraphicsPath grPath = new GraphicsPath();
                grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
                this.Region = new System.Drawing.Region(grPath);
                base.OnPaint(e);
            }
    
            private void InitializeComponent()
            {
                this.SuspendLayout();
                this.ResumeLayout(false);
    
            }
        }
    
    }
