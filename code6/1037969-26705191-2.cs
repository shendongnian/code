    public class MyUserControl : UserControl
    {
        // public event EventHandler MyControlClick;
        public event Action<MyUserControl> MyControlClick
        public string ID {get; set;}
        public MyUserControl()
        {
            InitializeComponents();
            myPictureBox.Click += global_Click;
            myLabel1.Click += global_Click;
            myLabel2.Click += global_Click;
        }
        void global_Click(object sender, EventArgs e)
        {
            if (MyControlClick != null)
                // MyControlClick(this, EventArgs.Empty);
                MyControlClick(this);                 
        }
    }
