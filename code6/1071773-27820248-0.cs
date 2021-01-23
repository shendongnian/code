    public partial class Form1 : Form
    {
      private Button[] _Buttons;
      public Form1()
      {
        InitializeComponent();
        _Buttons = new Button[] { button0, button1, button2 };
      }
      public void SomeButtonAction(int index)
      {
        _Buttons[index].Text = "Changed text";
      }
    }
