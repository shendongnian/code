    class myForm : Form
    {
        protected void OnClick()
        {
            try
            {
                var data = Helper.SelectStudent();
                cmbTable.Items.AddRange(data);
            }
            catch (Exception ex)
            {
                lblInfo.Text = " Error reading the database.";
                lblInfo.Text += err.Message; ;
            }
        }
    }
    class HelperClass
    {
        public static List<string> SelectStudent()
        {
            List<string> data = new List<string>();
            MySqlConnection conn; // connection object;
            string connstring = "server=localhost;user Id=root;database=collegesystem;Convert Zero Datetime=True ";
            conn = new MySqlConnection(connstring);
            conn.Open();
            MySqlCommand myCommand = new MySqlCommand("SELECT * FROM person", conn);
            MySqlDataReader myReader;
            myReader = myCommand.ExecuteReader();
            cmbTable.Items.Clear();
            while (myReader.Read())
            {
                data.Add(myReader["personID"] + " | " + myReader["firstName"] + " | " + myReader["lastName"] + " | " + myReader["address"] + " | " + myReader["phoneNumber"] + " | " + myReader["postCode"] + " | " + myReader["dateOfBirth"]);
            }
            return data;
        }
    }
