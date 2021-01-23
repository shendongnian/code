    public partial class Form2 : Form
    {
    public Form2()
    {
        InitializeComponent();
    }
    private void btnExit_Click(object sender, EventArgs e)
    {
        Environment.Exit(0);
    }
    private void btnShow_Click(object sender, EventArgs e)
    {
        Form1 frm1 = new Form1();
           int val = ((Form1 )this.Owner).GetValue();
           MessageBox.Show(string.Format(val.ToString(), "My Application", MessageBoxButtons.OK));
    }
    }
