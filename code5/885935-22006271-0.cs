    private void btnSAVE_Click(object sender, EventArgs e)
    {
      if(validateEntries())
     {
      XmlTextWriter w = new XmlTextWriter(fn, Encoding.UTF8);
      w.Formatting = Formatting.Indented;
      w.WriteStartDocument();
      w.WriteStartElement("employees");
      for (int i = 0; i < addCount; i++)
      {
          w.WriteStartElement("employees");
          w.WriteElementString("employeeID", employeeID[i].ToString());
          w.WriteElementString("employeeName", employeeName[i]);
          w.WriteElementString("jobTitle", jobTitle[i]);
          w.WriteElementString("address", address[i]);
          w.WriteElementString("telephoneNumber", telephoneNumber[i].ToString());
          w.WriteElementString("email", email[i]);
          w.WriteEndElement();
      } w.WriteEndElement();
      w.WriteEndDocument();
      w.Close();
      Application.Exit();
    }
    }
       public bool VailidateEntries()
        {
          if (txtNAME.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Name should not be empty");
                txtNAME.Focus();
                return false;
            }
          if (!(txtMailId.Text.Trim() == string.Empty))
          {
            if (!IsEmail(txtMailId.Text))
            {
                MessageBox.Show("Please enter valid Email Id's" );
                txtMailId.Focus();
                return false;
            }
         }
            if (!(txtPhone.Text.Trim() == string.Empty))
                {
                    if (!IsPhone(txtPhone.Text))
                    { 
                        MessageBox.Show("Invalid Phone Number");
                        txtPhone.Focus();
                        return false;
                    }
                   
                }
        }
        private bool IsEmail(string strEmail)
            {
                Regex validateEmail = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                return validateEmail.IsMatch(strEmail);
            }
       
            private bool IsPhone(String strPhone)
            {
                Regex validatePhone = new Regex("^([0-9]{3}|[0-9]{3})([0-9]{3}|[0-9]{3})[0-9]{4}$");
                return validatePhone.IsMatch(strPhone);
            }
