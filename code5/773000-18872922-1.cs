    public class Form1 : Form
    {
        public void SetLabelText(String TextToSet)
        {
            label_name.Text = TextToSet;
        }
    }
    
    //from Form2...
    login_form.SetLabelText("Hello World");
