    public class MyTextBox : TextBox, IUserControlStuff
    {
        public void MyTextBoxStuff()
        {
            ...
        }
        public void MyUserControlStuff()
        {
            ...
        }
    }
    public interface IUserControlStuff
    {
        public void MyUserControlStuff();
    }
