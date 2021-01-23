        string Name;
        public Form2(string CName)
                {
                    InitializeComponent();
                    Name= Cname;
                }
       private void Button_Click(object sender, EventArgs e)
      {
            Form3 form = new Form3(Name);
            form.Show();
            this.Close();
       }
