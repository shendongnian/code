        public Form1()
        {
            InitializeComponent();
            this.Shown += (s, e) => {
                String[] arguments = Environment.GetCommandLineArgs();
                if (arguments.Length > 1)
                {
                    Int16 valueArgument = Int16.Parse(arguments[1]); 
                    switch (valueArgument)
                    {
                        case 1:
                            this.Process1();
                            break;
                    }
                }
            };
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Process1();
        }
        public void Process1()
        {
            var dialog = new SaveFileDialog();
            dialog.Title = "Save file as...";
            dialog.Filter = "XML Files (*.xml)|*.xml";
            dialog.RestoreDirectory = true;
            dialog.ShowDialog(this);
            //dialog.InitialDirectory = @"v:\";
            //blah blah blah...... code here..
        }
   
