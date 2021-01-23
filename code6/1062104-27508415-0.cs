    public class MyTextBox : TextBox
    {
        public void TriggerKeyPress(KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }
    }
