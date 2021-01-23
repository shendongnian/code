     public partial class Form1 : Form
        {
            internal static Form1 ViewForm1; // make other form run Public void
            public form1()
            {
                InitializeComponent();
                ViewForm1 = this;  //Add this
            }
            public void DoSomething()
            {
              //Code...
            }
    }
    ......................
     public partial class Form1 : Form
        {
            public form2()
            {
                InitializeComponent();            
                Form1.ViewForm1.ShowData(); // call public void from form1
            }
