    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            IsMdiContainer = true;
            //Find the MdiClient and hold it by a variable
            client = Controls.OfType<MdiClient>().First();
            //This will check whenever client gets focused and there aren't any
            //child forms opened, Send the client to back so that the other controls can be shown back.
            client.GotFocus += (s, e) => {
                if (!MdiChildren.Any(x => x.Visible)) client.SendToBack();
            };
        }
        MdiClient client;
        //This is used to show a child form
        //Note that we have to call client.BringToFront();
        private void ShowForm(Form childForm)
        {
            client.BringToFront();//This will make your child form shown on top.
            childForm.Show();            
        }
        //button1 is a button on your Form1 (Mdi container)
        //clicking it to show a child form and see it in action
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2 { MdiParent = this };
            ShowForm(f);         
        }     
    }
