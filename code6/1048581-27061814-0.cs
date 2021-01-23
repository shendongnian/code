       void ClassCombo()       
        try
        {
            con = new SqlConnection(Properties.Settings.Default.MyConnection);
            cmd = new SqlCommand("SELECT * FROM Classes", con);
            cmd.Connection.Open();
            SqlDataReader readClass = cmd.ExecuteReader();
            ArrayList ClassList = new ArrayList();
            int i=0;
            while (readClass.Read())
            {
                ClassList.Add(readClass["class"].ToString());
                i++;
            }
            readClass.Close();
            cmd.Connection.Close();
            this.comboBoxClassID.DataSource = ClassList;
            this.comboBoxClassID.DisplayMember = "Display";
            this.comboBoxClassID.ValueMember = "Value";
            classHaveBeenAdded = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
