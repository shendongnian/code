    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Declare your new form
            Form2 form2 = new Form2();
            //Register the update event
            form2.updateEvent += new EventHandler(handleUpdateEvent);
            //Register form closed event
            form2.FormClosed += new FormClosedEventHandler(form2_FormClosed);
            Visible = false;
            //Show your new form
            form2.Show();
        }
        void form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }
        //Handler for the event from form 2
        void handleUpdateEvent(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }
    }
