    private Class Contact
    {
        public String Name { get; set; }
        public String Number{ get; set; }
        public String Mail { get; set; }
    }
    List<Contact> _listContact = new List<Contact>();
    private void Form_Load(object sender, EventArgs e)
    {
      AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
      SqlConnection con = new SqlConnection(@"***my connection string***");
      con.Open();
      SqlCommand cmnd = con.CreateCommand();
      cmnd.CommandType = CommandType.Text;
      cmnd.CommandText = "SELECT * FROM tblTicketDetail";        
      SqlDataReader dReader;
      dReader = cmnd.ExecuteReader();
      if (dReader.Read())
       {
         while (dReader.Read())
         {
            namesCollection.Add(dReader["ContactPerson"].ToString());
            Contact cont = Contact{Name = dReader["ContactPerson"].ToString(),
                                  Number = dReader["ContactNumber"].ToString()
                                  Mail = dReader["ContactMail"].ToString() }
            _listContact.add(cont);
         }
       }
      else
       {
          MessageBox.Show("Data not found");
       }
      dReader.Close();
 
    }
