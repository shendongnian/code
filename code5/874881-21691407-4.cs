    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WinFroms_21681229
    {
        public partial class MainForm : Form
        {
            public MainForm()
            {
                InitializeComponent();
    
                this.Shown += MainForm_Shown;
            }
    
            void MainForm_Shown(object sender, EventArgs e)
            {
                MessageBox.Show("Before");
    
                this.BackColor = Color.FromName("red");
                this.Invalidate();
    
                // the form is not getting red for another 15 seconds
                var array = new double[] { 1, 2, 3 };
                Parallel.For(0, array.Length, (i) =>
                {
                    System.Threading.Thread.Sleep(5000);
                    Debug.Print("data: " + array[i]);
                });
    
                MessageBox.Show("After");
            }
        }
    }
