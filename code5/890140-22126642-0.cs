        public Form1()
        {
            InitializeComponent();
            //Create right click menu..
            ContextMenuStrip s = new ContextMenuStrip();
            
            // add one right click menu item named as hello           
            ToolStripMenuItem hello = new ToolStripMenuItem();
            hello.Text = "Hello";
            // add the clickevent of hello item
            hello.Click += hello_Click;
            // add the item in right click menu
            s.Items.Add(hello);
            // attach the right click menu with form
            this.ContextMenuStrip = s;
        }
        void hello_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello Clicked");
        }
