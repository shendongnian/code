    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
    
            /// <summary>
            /// Gets the value selected in the NumericUpDown as an int.
            /// </summary>
            public int SelectedValue { get { return Convert.ToInt32(this.numericUpDown1.Value); } }
            /// <summary>
            /// Raised when the value in the NumericUpDown changes.
            /// </summary>
            public event EventHandler SelectedValueChanged;
    
            private void numericUpDown1_ValueChanged(object sender, EventArgs e)
            {
                if (this.SelectedValueChanged != null)
                {
                    // Notify any listeners that the selection has changed.
                    this.SelectedValueChanged(this, EventArgs.Empty);
                }
            }
        }
    }
