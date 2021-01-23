    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private Form2 form2Instance;
    
            private void button1_Click(object sender, EventArgs e)
            {
                // Check whether there is already a Form2 instance open.
                if (this.form2Instance == null || this.form2Instance.IsDisposed)
                {
                    // Create a new Form2 instance and handle the appropriate event.
                    this.form2Instance = new Form2();
                    this.form2Instance.SelectedValueChanged += form2Instance_SelectedValueChanged;
                }
    
                // Make sure the Form2 instance is displayed and active.
                this.form2Instance.Show();
                this.form2Instance.Activate();
            }
    
            private void form2Instance_SelectedValueChanged(object sender, EventArgs e)
            {
                // Update the ComboBox based on the selection in Form2.
                this.comboBox1.SelectedIndex = this.form2Instance.SelectedValue;
            }
        }
    }
