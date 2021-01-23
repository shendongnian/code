    public partial class Form1 : Form
    {
       private HelperClass helper;
       public Form1()
       {
           helper = new HelperClass();
       }
       public void SomeOtherFunction()
       {
           MyTextBox.Text = helper.Function4(MyTextBox.Text);
       }
    }
    public class HelperClass()
    {
        public string Function4(string input)  // I need a better name
        {
           // Do a bunch of stuff that depends on the input value and even manipulates it
           return ???  // Some other value, perhaps from the previous stuff you did
        }
    }
