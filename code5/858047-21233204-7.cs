    public class FormA : Form, ICustomerForm
    {
       public string Name
       {
          get
          {
             return _textBoxName.Text;
          }
          set
          {
             _textBoxName.Text = value;
          }
       }
