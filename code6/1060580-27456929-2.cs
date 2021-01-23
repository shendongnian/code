        public MyLabel()
        {
            InitializeComponent();
            this.VisibleChanged += new EventHandler(MyLabel_VisibleChanged);
        }
        void MyLabel_VisibleChanged(object sender, EventArgs e)
        {
            CheckLabels();
        }
        public void CheckLabels()
        {
            bool AllHidden = true;
            foreach (System.Windows.Forms.Control c in this.FindForm().Controls)
            {
                if (c.GetType().Name == "MyLabel")
                {
                    if (c.Visible == true)
                    {
                        AllHidden = false;
                        break;
                    }
                }
            }
            if (AllHidden)
            {
                //Do whatever you want. For example:
                this.FindForm().Close();
            }
        }
