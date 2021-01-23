    public partial class Form1 : Form
    {
        public Form1()
        {
            box = richtextbox_in_gui;
        }
        public void AppendText(string text)
        {
          this.textbox.AppendText(text);
        }
    }
    public class SomeClass
    {
      private Form1 form;
      public SomeClass(Form1 form)
      {
        this.form = form;
      }
      public void AppendHelloWorld()
      {
        this.form.AppendText("Hello World");
      }
    }
