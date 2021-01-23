    public class NewForm : Form
    {
        ...
        public NewForm(string constructorMessage)
        {
            //Shows the message "Constructing!!!" once and only once, this method will 
            //never be called again by GetInstance
            MessageBox.Show(constructorMessage);
        }
        public void Initialize(string message)
        {
            //Shows the message box every time, with whatever values you provide
            MessageBox.Show(message);
        }
    }
