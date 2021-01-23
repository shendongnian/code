    using System;
    using System.Windows.Forms;
    namespace SimpleViewModel
    {
        public partial class Form1 : Form
        {
            protected ViewModel MyResultViewModel = new ViewModel();
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                ResultForm form = new ResultForm(MyResultViewModel);
                form.Show();
                MyResultViewModel.Result = "42";
            }
        }
    }
