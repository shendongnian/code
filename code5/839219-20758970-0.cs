    using System.Windows.Forms;
    using System.Drawing;
    ...
    
    public class ChildForm : System.Windows.Forms.Form {
        public ChildForm() {
            this.BackColor = Color.FromKnownColor(KnownColor.Window);
            var lbl = new Label { Text = "Hello world" };
            this.Controls.Add(lbl);
        }
    }
