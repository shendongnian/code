    public partial class Form2 : Form
    {
      public Form2(string fileName)
      {
        InitializeComponent();
        textBox1.Text = File.ReadAllText(fileName);
      }
    }
