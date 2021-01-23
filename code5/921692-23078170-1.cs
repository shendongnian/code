        public Form1(){
     InitializeComponent();
                Create(this);
           
            }
          
            public static void Create(Form1 F)
            {
                //this works:
                F.Text = "DEFAULT TEXT";
                Panel test = new Panel();
                test.Dock = DockStyle.Fill;
                test.BackColor = Color.Blue;
               
                //test.Show(); this is irrelevant
                //this does not:
                F.Controls.Add(test);
