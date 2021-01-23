    namespace WindowsFormsApplication1
    {
       public partial class Form1 : Form
       {
          public Form1()
          {
             InitializeComponent();
          }
          private void button1_Click(object sender, EventArgs e)
          {
             string aValue = String.Empty;
             Something a = new Something();
             a.SomeThingElse = aValue;
          }
       }
       public class Something
       {
          public string SomeThingElse
          {
             get { return SomeThingElse; }
             set { SomeThingElse = value; }
          }
       }
    }
