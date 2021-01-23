    int privilege = 0;
    try
    {                
        //This is command class which will handle the query and connection object.
        string Query = "SELECT`tbl_user_login`.`u_id`,`tbl_user_login`.`u_username`,
                 `tbl_user_login`.`u_password`,`tbl_user_login`.`u_privilege` 
                 FROM `bcasdb`.`tbl_user_login`WHERE `tbl_user_login`.`u_username` = 
                 @username AND `tbl_user_login`.`u_password` = @password";
        MySqlConnection conn = 
                     new MySqlConnection(BCASApp.DataModel.DB_CON.connection);
        MySqlCommand cmd = new MySqlCommand(Query, conn);
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@password", password);
        MySqlDataReader MyReader;
        conn.Open();
        MyReader = cmd.ExecuteReader();
          // Here our query will be executed and data saved into the database.
        if (MyReader.HasRows && this.Frame != null)
        {
            while (MyReader.Read())
            {
                privilege = MyReader.GetInt32(3)
                if (privilege == 1)
                {
                    DisplayMsgBox("click ok to open the admin page ", "OK");
                }
                if (privilege == 2)
                {
                    DisplayMsgBox("click ok to open the staff page ", "OK");
                }
                else
                {
                    DisplayMsgBox("privilege 0", "ok");
                }   
            }
        }                
        else
        {
            DisplayMsgBox("sucess else", "ok");
        }
        conn.Close();
    }
    catch (Exception )
    {
        DisplayMsgBox("sucess catch", "ok");
    }
