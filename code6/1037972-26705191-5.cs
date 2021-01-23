    public class MyUserControl : UserControl
    {
        public event Action<MyUserControl> MyControlClick
        public string ID {get; set;}
        public MyUserControl()
        {
            InitializeComponents();
            // The same event handler code will be used for the three controls
            myPictureBox.Click += global_Click;
            myLabel1.Click += global_Click;
            myLabel2.Click += global_Click;
            this.Click += global_Click;
        }
        void global_Click(object sender, EventArgs e)
        {
            if (MyControlClick != null)
                MyControlClick(this);
        }
    }
