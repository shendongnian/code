    namespace DelimiterStage1
    {
        public partial class Form2 : Form
        {
            public Form2(MyDelegate delgt)
            {
                InitializeComponent();
                delgate_Form2 = delgt;
            }
            MyDelegate delgate_Form2;
            private void button1_Click(object sender, EventArgs e)
            {
                delgate_Form2();
            }
        }
    }
