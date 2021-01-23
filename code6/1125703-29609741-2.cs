    public class Form1 : Form
    {
        // Class variable to have a reference to Form2
        private Form2 form2;
        // Constructor
        public Form1()
        {
            // InitializeComponent is a default method created for you to intialize all the controls on your form.
            InitializeComponent();
            form2 = new Form2(this);
        }
        public String Return_inf()
        {
            names = U_name.Text;
            return names;
        }
    }
