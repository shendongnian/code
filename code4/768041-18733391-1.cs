    private void btnInsert_Click(object sender, EventArgs e)
    {
        studentHelperClass.insertStudent(studentIdTextBox.Text);
    }
    public static void insertStudent(string studentId)
    {
        MySqlConnection conn = connection();
        conn.Open();
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = conn;
        string myInsertSQL = "INSERT INTO person(personID) ";
        cmd.Prepare();
        myInsertSQL += "VALUES (@personID)";
        cmd.CommandText = myInsertSQL;        
        cmd.Parameters.AddWithValue("@personID", studentId);
        prevID(conn, cmd);
    }
