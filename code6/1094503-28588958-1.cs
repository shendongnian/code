    public partial class Form1 : Form
    {
        List<MyUserControl> myUserControls = new List<MyUserControl>();
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 4; i++) addNewUserControl();
        }
        void addNewUserControl()
        {
            MyUserControl userControl = new MyUserControl();
            userControl.Click += userControl_Click;
            myUserControls.Add(userControl);
            tableLayoutPanel1.Controls.Add(userControl);
        }
        void userControl_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < myUserControls.Count; i++) myUserControls[i].IsClicked = false;
            ((MyUserControl)sender).IsClicked = true;
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < myUserControls.Count; i++)
                if (myUserControls[i].IsClicked)
                {
                    MyUserControl userControl = myUserControls[i];
                    tableLayoutPanel1.Controls.Remove(userControl);
                    myUserControls.RemoveAt(i);
                    userControl.Dispose();                
                }
        }
    }
