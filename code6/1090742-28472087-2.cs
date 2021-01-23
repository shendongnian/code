    string constring = "Database=fillupform;Data Source=localhost;User Id=root;Password=''";
    string Query = "INSERT INTO fillupform.fillupform (filename,instructor,time,score) VALUES (@filename,@instructor,@time, @score);";
    using (MySqlConnection conDataBase = new MySqlConnection(constring))
    {
        using (MySqlCommand cmdDatabase = new MySqlCommand(Query, conDataBase))
        {
            cmdDatabase.CommandType = CommandType.Text;
            cmdDatabase.Parameters.AddWithValue("@filename", this.filename.Text);
            cmdDatabase.Parameters.AddWithValue("@instructor", this.instructor.Text);
            cmdDatabase.Parameters.AddWithValue("@time", this.timeanddate.Text);
            cmdDatabase.Parameters.AddWithValue("@score", this.score.Text);
            try
            {
                cmdDatabase.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
