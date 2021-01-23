        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void buttons_Click(object sender, EventArgs e)
            {
                Button b = sender as Button;
    
                switch (b.Name)
                {
                    //of course after each ClearPanel what i do is only for
                    //demonstration.
                    case "btnControl1":
                        splitContainer1.Panel2.SuspendLayout();
                        ClearPanel();
                        splitContainer1.Panel2.Controls.Add(new ListBox());
                        splitContainer1.Panel2.ResumeLayout();
                        break;
                    case "btnControl2":
                        splitContainer1.Panel2.SuspendLayout();
                        ClearPanel();
                        splitContainer1.Panel2.Controls.Add(new RadioButton());
                        splitContainer1.Panel2.ResumeLayout();
                        break;
                    case "btnControl3":
                        splitContainer1.Panel2.SuspendLayout();
                        ClearPanel();
                        splitContainer1.Panel2.Controls.Add(new Button());
                        splitContainer1.Panel2.ResumeLayout();
                        break;
                    case "btnControl4":
                        splitContainer1.Panel2.SuspendLayout();
                        ClearPanel();
                        splitContainer1.Panel2.Controls.Add(new DateTimePicker());
                        splitContainer1.Panel2.ResumeLayout();
                        break;
                    case "btnControl5":
                        splitContainer1.Panel2.SuspendLayout();
                        ClearPanel();
                        splitContainer1.Panel2.Controls.Add(new DataGridView());
                        splitContainer1.Panel2.ResumeLayout();
                        break;
                    case "btnControl6":
                        splitContainer1.Panel2.SuspendLayout();
                        ClearPanel();
                        splitContainer1.Panel2.Controls.Add(new TextBox());
                        splitContainer1.Panel2.ResumeLayout();
                        break;
                    default:
                        break;
                }
            }
    
            private void ClearPanel()
            {
                if (splitContainer1.Panel2.HasChildren)
                {
                    foreach (Control c in splitContainer1.Panel2.Controls)
                    {
                        c.Dispose();
                    }
                    splitContainer1.Panel2.Controls.Clear();
                }
            }
        }
