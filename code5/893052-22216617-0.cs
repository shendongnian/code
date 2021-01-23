    public class Main : Form
    {
        public Form() 
        {
            SuspendLayout();
            var label1 = new Label();
            var txtbx1 = new TextBox();
            label1.UseMnemonic = true;
            label1.Text = "First &Name:";
            label1.Location = new Point(15, 15);
            label1.BackColor = Color.Pink;
            label1.ForeColor = Color.Maroon;
            label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label1.Size = new Size(label1.PreferredWidth, label1.PreferredHeight + 2);
            txtbx1.Text = "Enter Your Name";
            txtbx1.Location = new Point(15 + label1.PreferredWidth + 5, 15);
            txtbx1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtbx1.BackColor = Color.LightGray;
            txtbx1.ForeColor = Color.Maroon;
            txtbx1.Size = new Size(90, 20);
            Controls.Add(label1); 
            Controls.Add(txtbx1);
            ResumeLayout();
        }
    }
