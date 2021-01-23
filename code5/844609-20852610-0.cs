        SqlDataReader reader = cmd.ExecuteReader();
            bool _doc, _nurse, _admin;
            while (reader.Read()) //For Doctor
            {
                _doc = true;
                timer1.Enabled = true;
                break;
            }
            
            reader.NextResult();
            
            while (reader.Read()) //For Nurse
            {
                _nurse = true;
                timer2.Enabled = true;
                break;
            }
            reader.NextResult();
            while (reader.Read()) //For Admin
            {
                _admin = true;
                timer3.Enabled = true;
                break;
            }
            reader.Close();
            if (!_doc && !_nurse && !_admin)
                MessageBox.Show("Unable to login for Doctor,Nurse and Admin.");
            else
                MessageBox.Show("Login successful for " + (_doc ? "Doctor" : string.Empty) + (_nurse ? ", Nurse" : string.Empty) + (_admin ? ", Admin" : string.Empty));
