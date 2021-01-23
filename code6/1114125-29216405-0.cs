    public partial class TestForm : Form
    {
        public TestForm()
        {
            btnSubmit.Click += new button_click;
        }
        public void button_click(object sender, EventArgs e)
        {
            // do some code
            SecondMethod();
        }
        public void SecondMethod()
        {
            // Do some more code that has to wait until first method is done.
            ThirdMethod()
        }
        public void ThirdMethod()
        {
            // Do your final code.
        }
    }
