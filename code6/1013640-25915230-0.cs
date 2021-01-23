        public Form1()
        {
            InitializeComponent();
            
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Class1 bl = new Class1();
            bl.f = this;
            bl.Process(backgroundWorker1);
        }
        public delegate void AddListBoxItemDelegate(object item);
        public void AddListBoxItem(object item)
        {
            if (this.listBox1.InvokeRequired)
            {
                // This is a worker thread so delegate the task.
                this.listBox1.Invoke(new AddListBoxItemDelegate(this.AddListBoxItem), item);
            }
            else
            {
                // This is the UI thread so perform the task.
                this.listBox1.Items.Add(item);
            }
        }
