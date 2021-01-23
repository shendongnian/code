    public partial class Form1 : Form
    {
       public void function4()
       {
           var currentText = MyTextBox.Text;
           // Do a bunch of stuff that depends on the Text value and even manipulates it
           MyTextBox.Text = ??? // Some other value
       }
       public void SomeOtherFunction()
       {
           function4();
       }
    }
