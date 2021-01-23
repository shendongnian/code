    public partial class BaseForm : Form
    {
      public BaseForm()
      {
        InitializeComponent();
        // "myPanel" is the panel where the button will be added in inherited forms
        myPanel.ControlAdded += myPanel_ControlAdded;
      }
      private void myPanel_ControlAdded(object sender, ControlEventArgs e)
      {
        var button = e.Control as Button;
        if (button != null)
        {
          button.FlatStyle = FlatStyle.Flat;
          button.ForeColor = Color.Red;
        }
      }
    }
