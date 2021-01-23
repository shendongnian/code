    public class NewForm : Form
    {
        ...
        public NewForm(string constructorMessage)
        {
            MessageBox.Show("This will only be shown once and only the first value you've provided to GetInstance: " + constructorMessage);
        }
        public void Initialize(string message)
        {
            MessageBox.Show("This will be shown each time with the value you provided to Initialize: " + message);
        }
    }
