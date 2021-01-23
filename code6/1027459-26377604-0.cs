    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    
    class BackgroundImageLabel : Label {
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Image BackgroundImage {
            get {
                return base.BackgroundImage;
            }
            set {
                base.BackgroundImage = value;
            }
        }
    }
