    public interface IForm
    {
        string MyString { get; }
    }
    public class MyUserControl : UserControl
    {
         public IForm Form { get; set; }
         private void ShowMyString()
         {
              String myString = Form.MyString;
              ...
         }
    }
