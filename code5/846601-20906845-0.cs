    public class Form1 : Form
    {
        private TextBox textbox1;
        public string Username { get { return textbox1.Text; } }
    }
    public class Form2 : Form
    {
        private Label label1;
        private TextBox textbox1;
        public string Username
        {
            get { return label1.Text; }
            set
            {
                label1.Text = value;
                textbox1.Text = value;
            }
        }
    }
---
    Form1 login = new Form1();
    Application.Run(login);
    Form2 main = new Form2();
    main.Username = login.Username;
    Application.Run(main);
