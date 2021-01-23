    public partial class Form1 : Form
    {
      private Dictionary<int, Button> _Buttons;
      public Form1()
      {
        InitializeComponent();
        _Buttons = new Dictionary<int, Button>
        {
          { 1, button1 },
          { 3, button3 }
        };
      }
      public void SomeButtonAction(int index)
      {
        Button button;
        if (_Buttons.TryGetValue(index, out button))
        {
          button.Text = "Changed text";
        }
      }
    }
    
    
