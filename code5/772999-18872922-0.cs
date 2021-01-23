    public class Form1 : Form
    {
        public String LabelText
        {
            get { return label_name.Text; }
            set { label_name.Text = value; }
        }
    }
    
    //from Form2...
    login_form.LabelText = "Hello World";
    
