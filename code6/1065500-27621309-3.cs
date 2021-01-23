    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace FormToFormExample
    {
        public partial class Form1 : Form
        {
            #region Constructors
            public Form1()
            {
                InitializeComponent();
                Initialize();
                BindComponents();
            } 
            #endregion
    
            #region Methods
            private void BindComponents()
            {
                this.button1.Click += button1_Click;
            }
    
            private void Initialize()
            {
                this.textBox1.Text = string.Empty;
            } 
            #endregion
    
            #region Events
            void button1_Click(object sender, EventArgs e)
            {
                Form2 form2 = new Form2(new EmployeeModel(textBox1.Text));
                form2.ShowDialog();
    
                Initialize();
            } 
            #endregion
        }
    }
