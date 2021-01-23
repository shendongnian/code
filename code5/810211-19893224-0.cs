        private string password;
        public Password()
        {
            InitializeComponent();
        }
        private void pass_TextChanged(object sender, EventArgs e)
        {
            password = "1234";
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            if (passtextBox.Text == password)
            {
             // list form = new list();
             //form.Show();
                 //list secondform = new list();
                  //secondform.Show();
                  //Password firstform = new Password();
                // firstform.Hide();
               this.Hide();
                list sistema = new list();
                sistema.ShowDialog();
                this.Close();
                
                
            }
           else
            {
                MessageBox.Show("Incorrect Password. Try Again!!");
            }
        }
        
    }
}
