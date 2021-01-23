     public partial class Form1 : Form
    {
        Form form2;  // be sure all componentes see all forms
        Form form3;
        Form form4;
        public Form1()
        {
            InitializeComponent();
            form2 = new Form();  // create new Forms
            form3 = new Form();
            var button = new Button();  
            button.Click += new EventHandler(button_Click); // tell the button what should be called when click
            form4 = new Form();  
            form4.Controls.Add(button);  // add button progrimicaly to form
        }
        void button_Click(object sender, EventArgs e)
        {
            form2.Hide();  // hide on click
            form3.Hide();
            form4.Hide();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            form2.Show();   // show on load
            form3.Show();
            form4.Show();
        }
    }
