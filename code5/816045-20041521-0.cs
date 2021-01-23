    public partial class Form1 : Form
    {
       private int secretValue;
       Form2 frm2 = new Form2();
    public  void SetValue (int value){
          secretValue = value;
    }
    public int GetValue ()
    {
       return secretValue;
    }
    public Form1()
    {
        InitializeComponent();
    }
    private void button2_Click(object sender, EventArgs e)
    {
       
        frm2 .Show();
        this.Hide();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
          frm2.Owner = this;
    }
    private void btnEnter_Click(object sender, EventArgs e)
    {
        secretValue = Convert.ToInt32(txtInput.Text);
        SetValue(secretValue);
    }
    }
