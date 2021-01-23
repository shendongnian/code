    //Example form with an inheritor that blocks us from using inheritence to apply style
    public class MainForm : 3rdPartyLibrary.WizardForm 
    {
      public MainForm()
      {
        ApplyStyle();
      }
    }
    //Normal form 
    public class MyDialog : Form
    {
      public MyDialog()
      {
        ApplyStyle();
      }
    }
    public static class WinFormExtension
    {
      public static void ApplyStyle(this Form form)
      {
        form.BackColor = Colors.NavyBlue;
        //etc
      }
