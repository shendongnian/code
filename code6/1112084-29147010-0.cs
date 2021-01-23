    public partial class FormThatNeedsStyle : Form
    {
      public FormThatNeedsStyle()
      {
        InitializeComponent();
        this.Style();
      }
    }
   
    // Extension method class to apply styles
    public static class Styles
    {
      public static void Style(this Form form)
      {
        form.BackColor = Color.HotPink;
   
        foreach (var control in form.Controls)
        {
          // Apply desired styles to controls within the form
          if (control is Button)
            (control as Button).Style();
        }
      }
   
      public static void Style(this Button button)
      {
        button.FlatStyle = FlatStyle.Flat;
      }
    }
