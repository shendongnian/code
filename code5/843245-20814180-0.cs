    using System;
    using System.Windows.Forms;
    
    class VerticalProgressBar : ProgressBar {
        protected override CreateParams CreateParams {
            get {
                var cp = base.CreateParams;
                cp.Style |= 4;   // Turn on PBS_VERTICAL
                return cp;
            }
        }
    }
