    public partial class Form1 : Form
    {
       public Form1()
       {
          InitializeComponent();
       }
       private void btnOpenForm2_Click(object sender, EventArgs e)
       {
          Form2 f2 = new Form2(this);
          f2.ShowDialog();
       }
       public string ListBoxValue
       {
          get { return listBox1.SelectedItem.ToString(); }
       }
    }
