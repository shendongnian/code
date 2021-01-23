    public partial class MyForm : Form
    {
       public MyForm()
       {
        InitializeComponent();
        this.myUserControl1.ParentForm = this;
       }
    }
