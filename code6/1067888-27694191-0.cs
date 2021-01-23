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
        var button = sender as Button;
        if (button != null)
        {
          button.ForeColor = Color.Red;
        }
      }
    }
