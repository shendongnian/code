        string Name;
        public Form3(string CName)
                {
                    InitializeComponent();
                    Name= Cname;
                }
        private void frmTicketandCottages_Load(object sender, EventArgs e)
                {
                    MessageBox.Show(Name); 
                }
