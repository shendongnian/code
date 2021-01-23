    using System;
    using System.Windows.Forms;
    using System.Drawing;
    
    class LabelForm : Form
    {
        Label label1;
        //
        public LabelForm()
        {
            label1 = new Label();
            label1.Text = "ClickMe";
            label1.Location = new Point(10, 10); // This is the place where you set the location of your label. Currently, it is set to 10, 10.
            label1.Click += new EventHandler(labelClick);
            Controls.Add(label1);
        }
        //
        static void Main(string[] args)
        {
            LabelForm lf = new LabelForm();
            Application.Run(lf);
        }
        //
        protected void labelClick(object o, EventArgs e)
        {
            MessageBox.Show("Left position of the label: " + label1.Left
                + "\nTop position of the label: " + label1.Top,
                "", MessageBoxButtons.OK);
        }
    }
