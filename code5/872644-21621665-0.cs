    public class Form2
    {
        public Form2()
        {
            InitializeComponent();
        }
        //add your own constructor, which also calls the other, parameterless constructor.
        public Form2(int a, int b, int c):this()
        {
            // add your handling code for your parameters here.
        }
    }
