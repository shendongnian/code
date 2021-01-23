    public class Main
    {
      public Main()
      {
        var form = new Form1();
        form.ShowDialog();
      }
    }
    
    public class Form1 : Form
    {
      private readonly Form2 _form2;
    
      public Form1()
        : this(null)
      {
        _form2 = new Form2(this);
      }
    
      public Form1(Form2 form2)
      {
        _form2 = form2;
        var button = new Button();
        button.Click += ButtonOnClick;
        Controls.Add(button);
      }
    
      private void ButtonOnClick(object sender, EventArgs eventArgs)
      {
        this.Hide();
        _form2.Show();
      }
    }
    
    public class Form2 : Form
    {
      private readonly Form1 _form1;
    
      public Form2(Form1 form2)
      {
        _form1 = form2;
        var button = new Button();
        button.Click += ButtonOnClick;
        Controls.Add(button);
      }
    
      private void ButtonOnClick(object sender, EventArgs eventArgs)
      {
        this.Hide();
        _form1.Show();
      }
    }
