    using System;
    using System.Linq;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void btnCal_Click(object sender, EventArgs e)
            {
                var tuples = from m in Enumerable.Range(1, int.Parse(txtM.Text))
                             from n in Enumerable.Range(1, int.Parse(txtN.Text))
                             select Tuple.Create(m, n);
                txtProduct.Text = "{" + String.Join(",", tuples) + "}";
            }
        }
    }
