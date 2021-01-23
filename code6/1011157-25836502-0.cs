    public partial class FirstForm: Form
    {
    public FirstForm()
    {
        InitializeComponent();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        SecondForm form2 = new SecondForm (this);
        SecondForm .Show();
    }
    public void UpdateDataGrid()
    {
    //add your code here
    }
     
    }
    public partial class SecondForm : Form
    {
    private FirstForm form1;
    public SecondForm ()
    {
        InitializeComponent();
    }
    public SecondForm (FirstForm form1)
        : this()
    {
        
        this.form1 = form1;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        form1.UpdateDataGrid();
    }
    }
