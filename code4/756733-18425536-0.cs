    SqlCommand cmd = con.CreateCommand();
    cmd.CommandText = "INSERT INTO Records 
                   ([Student ID], [First Name], [Last Name], [Middle Initial], 
                     Gender, Address, Status, Year, Email, Course, 
                    [Contact Number]) 
                    VALUES (@StudentID, @FirstName, @LastName , @MiddleInitial, 
                            @Gender, @Address, @Status, @Year, @Email, @Course, 
                            @ContactNumber)";
    Control[] controls = {textBox1,textBox2, textBox3, textBox4, textBox5, textBox6, comboBox1, comboBox2, comboBox3, comboBox4, comboBox5};
    foreach(Control c in controls){
      if(c.Text.Trim() == "") {
          MessageBox.Show("Please complete the fields", "Information...", 
                       MessageBoxButtons.OK, MessageBoxIcon.Warning, 
                       MessageBoxDefaultButton.Button1);
          c.Focus();//Focus it to let user enter some value again.
          return;
      }
    }
    //Initialize your parameters here
    //....
    //....
    //....
    
    try {
      cmd.ExecuteNonQuery();        
      MessageBox.Show("Data Inserted!", "Information ... ", 
                       MessageBoxButtons.OK, MessageBoxIcon.Information, 
                       MessageBoxDefaultButton.Button1);
      foreach(Control c in controls) c.Text = "";
    }catch{}
    finally {
      con.Close();
    }
