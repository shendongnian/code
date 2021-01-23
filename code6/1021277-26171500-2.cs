      public partial class Form2 : Form
    {
        private UserModel UserObject { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(UserModel userModel)
        {           
            InitializeComponent();
            this.UserObject = userModel;
        }
        private void btnSaveData_Click(object sender, EventArgs e)
        {
            using (MySqlCommand cmd = new MySqlCommand("insert into info(AccountId,Datum,Timmar,Rast) Values(@AccountId,@Datum,@Timmar,@Rast)", con))
            {
                DateTime now = DateTime.Now;
                cmd.Parameters.AddWithValue("@AccountId", UserObject.IdUser);
                cmd.Parameters.AddWithValue("@Datum", now);
                cmd.Parameters.AddWithValue("@Timmar", textBox2.Text);
                cmd.Parameters.AddWithValue("@Rast", textBox3.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sparat!");
                con.Close();
            } 
        }
    }
